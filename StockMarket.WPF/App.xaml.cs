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
using Microsoft.Extensions.DependencyInjection;
using StockMarket.EntityFramework;
using StockMarket.WPF.States.Navigators;
using StockMarket.WPF.ViewModels.Factories;
using StockMarket.WPF;


namespace StockMarket.WPF
{

    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
           
            IServiceProvider serviceProvider = CreateServiceProvider();

            //Window window = new MainWindow();
            //window.DataContext = new MainViewModel();
            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.DataContext = serviceProvider.GetRequiredService<MainViewModel>();
            window.Show();

            // Different Instance of a Scope:
            /*using (IServiceScope scope = serviceProvider.CreateScope()) 
            { 
                var differentViewModel = scope.ServiceProvider.GetRequiredService<MainViewModel>();
                var equal = differentViewModel == window.DataContext;
            }*/

            base.OnStartup(e);
        }


        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<DesignTimeDbContextFactory>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<IStockService, StockPriceService>();
            services.AddSingleton<IBuyStockService, BuyStockService>();
            services.AddSingleton<ITopStocksService, TopStocksService>();

            services.AddSingleton<IRootViewModelFactory, RootViewModelFactory>();
            services.AddSingleton<IViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
            services.AddSingleton<IViewModelFactory<TopStocksViewModel>, TopStocksViewModelFactory>();
            services.AddSingleton<IViewModelFactory<PortfolioViewModel>, PortfolioViewModelFactory>();
            services.AddSingleton<IViewModelFactory<ChartViewModel>, ChartViewModelFactory>();
            services.AddScoped<BuyViewModel>(); // retains the state (no deps injection)

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainViewModel>();

            services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }
    }

}




