using StockMarket.Domain.Services;
using StockMarket.FMPApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.WPF.ViewModels.Factories
{
    public class TopStocksViewModelFactory : IViewModelFactory<TopStocksViewModel>
    {
        private readonly ITopStocksService _topStockService;

        public TopStocksViewModelFactory(ITopStocksService topStockService)
        {
            _topStockService = topStockService;
        }

        public TopStocksViewModel CreateViewModel()
        {
            return TopStocksViewModel.LoadTopStocksViewModel(_topStockService);
        }
    }
}
