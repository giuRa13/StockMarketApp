using Newtonsoft.Json;
using StockMarket.Domain.Models;
using StockMarket.Domain.Services;
using StockMarket.Domain.Services.Transactions;
using StockMarket.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;


//using ScottPlot;
using System.Windows.Documents;
using StockMarket.WPF.Models;
using StockMarket.WPF.Controls;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Wpf;
using ScottPlot.Colormaps;
using OxyPlot.Axes;
using System.Security.Policy;
using OxyPlot.Contrib.Wpf;
using ScottPlot;
using ScottPlot.Statistics;
using ScottPlot.WPF;
using StockMarket.FMPApi.Services;
using ScottPlot.Plottables;


namespace StockMarket.WPF.ViewModels
{

    public class BuyViewModel : ViewModelBase
    {

        private string _symbol;
        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }

        private string _searchSymbol = string.Empty;
        public string SearchSymbol
        {
            get { return _searchSymbol; }
            set
            {
                _searchSymbol = value;
                OnPropertyChanged(nameof(SearchSymbol));
            }
        }

        private double _stockPrice;
        public double StockPrice
        {
            get { return _stockPrice; }
            set
            {
                _stockPrice = value;
                OnPropertyChanged(nameof(StockPrice));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }


        private int _sharesToBuy;
        public int SharesToBuy
        {
            get { return _sharesToBuy; }
            set
            {
                _sharesToBuy = value;
                OnPropertyChanged(nameof(SharesToBuy));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public double TotalPrice
        {
            get { return SharesToBuy * StockPrice; }
        }


        private TopStock _stock;
        public TopStock Stock
        {
            get { return _stock; }
            set
            {
                _stock = value;
                OnPropertyChanged(nameof(Stock));
            }
        }


        private ChartData _chartData;
        public ChartData ChartData
        {
            get { return _chartData; }
            set
            {
                _chartData = value;
                OnPropertyChanged(nameof(ChartData));
                OnPropertyChanged(nameof(Symbol));
            }
        }

        public ICommand SearchSymbolCommand { get; set; }
        public ICommand BuyStockCommand { get; set; }

        public WpfPlot plotControl { get; set; }
        public List<OHLC> prices { get; set; }

        /*public ScottPlot.Plottables.HorizontalLine HLine { get; set; }
        public ScottPlot.Plottables.VerticalLine VLine { get; set; }
        public ScottPlot.Plottables.Marker Marker { get; set; }

        public ScottPlot.Plottables.Crosshair CH { get; set; }
        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }*/


        public BuyViewModel(IStockService stockService, IBuyStockService buyStockService)
        {
            SearchSymbolCommand = new SearchSymbolCommand(this, stockService);
            BuyStockCommand = new BuyStockCommand(this, buyStockService);

            plotControl = new WpfPlot();
            prices = new List<OHLC>();

            //prices.Add(new OHLC(100, 200, 100, 100, DateTime.Now, TimeSpan.FromDays(1)));
            var candlePlot = plotControl.Plot.Add.Candlestick(prices);
            candlePlot.RisingColor = ScottPlot.Color.FromHtml("#089981"); //#00e676
            candlePlot.FallingColor = ScottPlot.Color.FromHtml("#f23645"); //#f23645 #ff5252

            plotControl.Plot.Axes.DateTimeTicksBottom();
            plotControl.Plot.FigureBackground.Color = new("#1c1c1e");
            plotControl.Plot.Axes.Color(new("#888888"));

            plotControl.Plot.Axes.Left.TickLabelStyle.IsVisible = false;
            plotControl.Plot.Axes.Left.MajorTickStyle.Length = 0;
            plotControl.Plot.Axes.Left.MinorTickStyle.Length = 0;
            plotControl.Plot.Axes.Top.FrameLineStyle.Width = 0;
            //WpfPlot1.Plot.Axes.Left.FrameLineStyle.Width = 0;
            plotControl.Plot.Axes.Left.FrameLineStyle.IsVisible = false;
            candlePlot.Axes.YAxis = plotControl.Plot.Axes.Right;
            plotControl.Plot.Axes.Right.TickGenerator = new ScottPlot.TickGenerators.NumericAutomatic()
            {
                LabelFormatter = (double value) => value.ToString("C")
            };

            plotControl.Plot.Grid.XAxisStyle.MajorLineStyle.Color = ScottPlot.Colors.White.WithAlpha(15);
            plotControl.Plot.Grid.YAxisStyle.MajorLineStyle.Color = ScottPlot.Colors.White.WithAlpha(15);
            plotControl.Plot.Grid.XAxisStyle.MinorLineStyle.Color = ScottPlot.Colors.White.WithAlpha(5);
            plotControl.Plot.Grid.YAxisStyle.MinorLineStyle.Color = ScottPlot.Colors.White.WithAlpha(5);

            /*HLine = plotControl.Plot.Add.HorizontalLine(0);
            HLine.LineWidth = 1;
            HLine.LineColor = Colors.Magenta;
            HLine.LinePattern = LinePattern.Dotted;
            VLine = plotControl.Plot.Add.VerticalLine(0);
            VLine.LineWidth = 1;
            VLine.LineColor = Colors.Magenta;
            Marker = plotControl.Plot.Add.Marker(0, 0);
            Marker.Color = Colors.Magenta;

            plotControl.MouseMove += (s, e) =>
            {
                Coordinates point = plotControl.Plot.GetCoordinates(
                    (float)e.GetPosition(plotControl).X * plotControl.DisplayScale,
                    (float)e.GetPosition(plotControl).Y * plotControl.DisplayScale);

                HLine.Position = point.Y;
                VLine.Position = point.X;
                Marker.Position = point;
                Text = $"X={point.X:c}, Y={point.Y:c}";
                plotControl.Refresh();
            };*/

            //plotControl.Plot.Axes.AutoScale();

            /*CH = plotControl.Plot.Add.Crosshair(0, 0);
            CH.TextColor = Colors.White;
            CH.TextBackgroundColor = CH.HorizontalLine.Color;

            plotControl.MouseMove += (s, e) =>
            {
                Coordinates point = plotControl.Plot.GetCoordinates(
                    (float)e.GetPosition(plotControl).X * plotControl.DisplayScale,
                    (float)e.GetPosition(plotControl).Y * plotControl.DisplayScale);

                //Pixel mousePixel = new(e.X, e.Y);
                //Coordinates mouseCoordinates = plotControl.Plot.GetCoordinates(mousePixel);
                Text = $"X={point.X:c}, Y={point.Y:N3}";
                CH.Position = point;
                CH.VerticalLine.Text = $"{DateTimeOffset.FromUnixTimeSeconds((long)point.X)}";
                CH.HorizontalLine.Text = $"{point.Y:c}";

                plotControl.Refresh();
            };*/

            plotControl.Refresh();

        }


    }  

}
