using StockMarket.Domain.Models;
using StockMarket.Domain.Services;
using StockMarket.Domain.Services.Transactions;
using StockMarket.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StockMarket.WPF.Commands
{
    public class BuyStockCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private BuyViewModel _buyviewModel;
        private IBuyStockService _buyStockService;

        public BuyStockCommand(BuyViewModel buyViewModel, IBuyStockService buyStockService)
        {
            _buyviewModel = buyViewModel;
            _buyStockService = buyStockService;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            try
            {
                Account account = await _buyStockService.BuyStock(new Account()
                {
                    Id = 1,
                    Balance = 500,
                    AssetTransactions = new List<AssetTransaction>()
                }, 
                _buyviewModel.Symbol, _buyviewModel.SharesToBuy);
                
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
        }


    }

}
