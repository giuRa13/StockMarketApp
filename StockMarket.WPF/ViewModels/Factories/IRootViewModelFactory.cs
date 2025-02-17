using StockMarket.WPF.States.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.WPF.ViewModels.Factories
{
    public interface IRootViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
