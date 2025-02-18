using StockMarket.FMPApi.Services;
using StockMarket.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.WPF.ViewModels.Factories
{
    public class RootViewModelFactory : IRootViewModelFactory
    {
        private IViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private IViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;
        private IViewModelFactory<ChartViewModel> _chartViewModelFactory;
        private readonly BuyViewModel _buyViewModel; // retains the state (no deps injection)
        private IViewModelFactory<LoginViewModel> _loginViewModelFactory;   

        public RootViewModelFactory(
            IViewModelFactory<HomeViewModel> hommeViewModelFactory,
            IViewModelFactory<PortfolioViewModel> portfolioViewModelFactory,
            IViewModelFactory<ChartViewModel> chartViewModelFactory,
            IViewModelFactory<LoginViewModel> loginViewModelFactory,
            BuyViewModel buyViewModel)
        {
            _homeViewModelFactory = hommeViewModelFactory;
            _portfolioViewModelFactory = portfolioViewModelFactory;
            _chartViewModelFactory = chartViewModelFactory;
            _buyViewModel = buyViewModel;
            _loginViewModelFactory = loginViewModelFactory;
        }


        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _loginViewModelFactory.CreateViewModel();
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.Portfolio:
                    return _portfolioViewModelFactory.CreateViewModel();
                case ViewType.Chart:
                    return _chartViewModelFactory.CreateViewModel();
                case ViewType.Buy:
                    return _buyViewModel;           
                default:
                    throw new ArgumentException("ViewType has not a ViewModel", "viewType");
            }
        }
    }
}
