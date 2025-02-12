using StockMarket.Domain.Models;
using StockMarket.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Services.Transactions
{
    public class BuyStockService : IBuyStockService
    {
        private readonly IStockService _stockService;
        private readonly IDataService<Account> _accountService;

        public BuyStockService(IStockService stockService, IDataService<Account> accountService)
        {
            _stockService = stockService;
            _accountService = accountService;
        }

        public async Task<Account> BuyStock(Account buyer, string symbol, int shares)
        {
            double stockPrice = await _stockService.GetPrice(symbol);
            double transactionPrice = stockPrice * shares;

            if(transactionPrice > buyer.Balance)
            {
                throw new InsuficentFundsException(buyer.Balance, transactionPrice);
            }

            AssetTransaction transaction = new AssetTransaction()
            {
                Account = buyer,
                Asset = new Asset()
                {
                    PricePerShare = stockPrice,
                    Symbol = symbol
                },
                DateProcessed = DateTime.Now,
                SharesAmount = shares,
                IsPurchase = true
            };

            buyer.AssetTransactions.Add(transaction);
            buyer.Balance -= transactionPrice;

            await _accountService.Update(buyer.Id, buyer);

            return buyer;
        }


    }

}
