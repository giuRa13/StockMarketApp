using StockMarket.WPF.ViewModels;
using StockMarket.WPF.Commands;
using System.Configuration;
using System.Data;
using System.Windows;
using StockMarket.FMPApi.Services;
using StockMarket.Domain.Models;
using StockMarket.Domain.Services;
using StockMarket.Domain.Services.Transactions;
using StockMarket.EntityFramework.Services;


namespace StockMarket.WPF
{

    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            /*new TopStocksService().GetStockFull(TopStockName.NVDA).ContinueWith((task) =>
            {
                var stocks = task.Result;
            });*/
            /*new StockPriceService().GetPrice("TSLA").ContinueWith((task) =>
            {
                var price = task.Result;
            });*/
            /*new StockPriceService().GetHistorical("TSLA", "2025-01-30").ContinueWith((task) =>
            {
                var price = task.Result;
            });*/

            IDataService<Account> accountService = new AccountDataService( new EntityFramework.DesignTimeDbContextFactory());
            //IDataService<Account> accountService = new GenericDataService<Account>(new EntityFramework.DesignTimeDbContextFactory());
            IStockService stockService = new StockPriceService();
            IBuyStockService buyStockService = new BuyStockService(stockService, accountService);

            Account buyer = await accountService.Get(1);
            await buyStockService.BuyStock(buyer, "COIN", 50);


            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();

            base.OnStartup(e);
        }
    }

}
