using StockMarket.FMPApi.Services;
using StockMarket.WPF.States.Navigators;
using StockMarket.WPF.ViewModels;
using StockMarket.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockMarket.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IRootViewModelFactory _viewModelAbstractFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IRootViewModelFactory viewModelAbstractFactory)
        {
            _navigator = navigator;
            _viewModelAbstractFactory = viewModelAbstractFactory;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
          
                _navigator.CurrentViewModel = _viewModelAbstractFactory.CreateViewModel(viewType);
            }
        }


    }

}
