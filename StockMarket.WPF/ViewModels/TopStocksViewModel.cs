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
    public class TopStocksViewModel : ViewModelBase
    {
        private readonly ITopStocksService _topStocksService;
        public TopStocksViewModel(ITopStocksService topStockService)
        {
            _topStocksService = topStockService;
        }
        

        private TopStock _apple;
        public TopStock Apple
        {
            get { return _apple; }
            set 
            { 
                _apple = value; 
                OnPropertyChanged(nameof(Apple));
            }
        }

        private TopStock _nvidia;
        public TopStock Nvidia
        {
            get { return _nvidia; }
            set
            {
                _nvidia = value;
                OnPropertyChanged(nameof(Nvidia));
            }
        }

        private TopStock _microsoft;
        public TopStock Microsoft
        {
            get { return _microsoft; }
            set
            {
                _microsoft = value;
                OnPropertyChanged(nameof(Microsoft));
            }
        }

        private TopStock _amazon;
        public TopStock Amazon
        {
            get { return _amazon; }
            set
            {
                _amazon = value;
                OnPropertyChanged(nameof(Amazon));
            }
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
            _topStocksService.GetStockFull(TopStockName.AMZN).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Amazon = task.Result;
                }
            });
        }
    }
}
