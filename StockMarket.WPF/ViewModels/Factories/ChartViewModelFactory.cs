using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.WPF.ViewModels.Factories
{
    public class ChartViewModelFactory : IViewModelFactory<ChartViewModel>
    {
        public ChartViewModel CreateViewModel()
        {
            return new ChartViewModel();
        }
    
    }
}
