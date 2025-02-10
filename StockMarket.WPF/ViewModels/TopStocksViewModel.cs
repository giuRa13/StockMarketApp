using StockMarket.Domain.Services;
using StockMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockMarket.FMPApi.Services;

namespace StockMarket.WPF.ViewModels
{
    public class TopStocksViewModel
    {
        private readonly ITopStocksService _topStocksService;

        public TopStock Apple {  get; set; }
        public TopStock Nvidia { get; set; }
        public TopStock Microsoft { get; set; }


        public TopStocksViewModel(ITopStocksService topStockService)
        {
            _topStocksService = topStockService;
        }


        public static TopStocksViewModel LoadTopStocksViewModel(ITopStocksService topStocksService)
        {
            TopStocksViewModel topStocksViewModel = new TopStocksViewModel(topStocksService);
            topStocksViewModel.LoadTopStocks();
            return topStocksViewModel;
        }

        private void LoadTopStocks()
        {
            _topStocksService.GetStockFull(TopStockName.AAPL).ContinueWith(task =>
            {
                if (task.Exception == null) 
                {
                    Apple = task.Result;
                }
            });
            _topStocksService.GetStockFull(TopStockName.NVDA).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Nvidia = task.Result;
                }
            });
            _topStocksService.GetStockFull(TopStockName.MSFT).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Microsoft = task.Result;
                }
            });
        }
    }
}
