using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.WPF.ViewModels.Factories
{
    public class HomeViewModelFactory : IViewModelFactory<HomeViewModel>
    {
        private IViewModelFactory<TopStocksViewModel> _topStocksViewModelFactory;

        public HomeViewModelFactory(IViewModelFactory<TopStocksViewModel> topStocksViewModelFactory)
        {
            _topStocksViewModelFactory = topStocksViewModelFactory;
        }

        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel(_topStocksViewModelFactory.CreateViewModel());
        }
    }
}
