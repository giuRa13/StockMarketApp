using StockMarket.WPF.ViewModels;
using StockMarket.WPF.Commands;
using System.Configuration;
using System.Data;
using System.Windows;

namespace StockMarket.WPF
{

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();

            base.OnStartup(e);
        }
    }

}
