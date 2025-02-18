using ScottPlot.WPF;
using ScottPlot;
using StockMarket.Domain.Models;
using StockMarket.Domain.Services;
using StockMarket.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection.Emit;
using StockMarket.WPF.Models;
using System.Windows.Media;

namespace StockMarket.WPF.Commands
{
    public class SearchSymbolCommand : ICommand
    {
        private BuyViewModel _viewModel;
        private IStockService _stockService;

        public event EventHandler? CanExecuteChanged;

        public SearchSymbolCommand(BuyViewModel viewModel, IStockService stockService) 
        { 
            _viewModel = viewModel;
            _stockService = stockService;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                TopStock stock = await _stockService.GetStock(_viewModel.Symbol);
                _viewModel.Stock = stock;
                _viewModel.SearchSymbol = stock.symbol;
                _viewModel.StockPrice = stock.price;

                string date = "";
                ChartData data = await _stockService.GetHistorical(_viewModel.Symbol, date);
                _viewModel.ChartData = data;
                _viewModel.Change = data.historical[0].changePercent;
                if (_viewModel.Change > 0)
                    _viewModel.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 8, 153, 129));
                else
                    _viewModel.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 82, 82));

                _viewModel.prices.Clear();
    
                foreach (var result in data.historical)
                {
                    double open = result.open;
                    double close = result.close;
                    double high = result.high;
                    double low = result.low;
                    double adjClose = result.adjClose;

                    DateTime dt = DateTime.Parse(result.date);
                    TimeSpan timeSpan = TimeSpan.FromDays(1);

                    _viewModel.prices.Add(new OHLC(open, high, low, close, dt, timeSpan));
                }


                /*DateTime startTime = new DateTime(2020, 12, 14, 0, 1, 0);
                DateTime endTime = new DateTime(2025, 01, 01, 23, 59, 0);
                double startTimeOA = startTime.ToOADate();
                double endTimeOA = endTime.ToOADate();
                _viewModel.plotControl.Plot.Axes.SetLimits(startTimeOA, endTimeOA, 0, 300);*/
                _viewModel.plotControl.Plot.Axes.AutoScale();

                _viewModel.plotControl.Refresh();

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
      
        }

       
    }
}
