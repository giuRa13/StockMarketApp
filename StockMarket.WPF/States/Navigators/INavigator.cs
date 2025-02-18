using StockMarket.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockMarket.WPF.States.Navigators
{
    public enum ViewType
    {
        Home,
        Portfolio,
        Chart,
        Buy,
        Login
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }

        ICommand UpdateCurrentViewModelCommand {  get; }
    }
}
