using StockMarket.FMPApi.Services;
using StockMarket.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.WPF.ViewModels.Factories
{
    public class ViewModelAbstractFactory : IViewModelAbstractFactory
    {
        private IViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private IViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;
        private IViewModelFactory<ChartViewModel> _chartViewModelFactory;

        public ViewModelAbstractFactory(
            IViewModelFactory<HomeViewModel> hommeViewModelFactory, 
            IViewModelFactory<PortfolioViewModel> portfolioViewModelFactory,
            IViewModelFactory<ChartViewModel> chartViewModelFactory ) 
        {
            _homeViewModelFactory = hommeViewModelFactory;
            _portfolioViewModelFactory = portfolioViewModelFactory;
            _chartViewModelFactory = chartViewModelFactory;
        }
        
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                    break;
                case ViewType.Portfolio:
                    return _portfolioViewModelFactory.CreateViewModel();
                    break;
                case ViewType.Chart:
                    return _chartViewModelFactory.CreateViewModel();
                    break;
                default:
                    throw new ArgumentException("ViewType has not a ViewModel", "viewType");
            }
        }
    }
}
