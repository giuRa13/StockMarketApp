using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public TopStocksViewModel TopStocksViewModel { get; set; }


        public HomeViewModel(TopStocksViewModel topStocksViewModel)
        {
            this.TopStocksViewModel = topStocksViewModel;
        }

        
    }
}
