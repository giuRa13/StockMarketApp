using StockMarket.WPF.ViewModels;
using StockMarket.WPF.Commands;
using System.Configuration;
using System.Data;
using System.Windows;
using StockMarket.FMPApi.Services;
using StockMarket.Domain.Models;

namespace StockMarket.WPF
{

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            /*new TopStocksService().GetStockFull(TopStockName.NVDA).ContinueWith((task) =>
            {
                var stocks = task.Result;
            });*/

            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();

            base.OnStartup(e);
        }
    }

}
