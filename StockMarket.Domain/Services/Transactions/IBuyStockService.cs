using StockMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Services.Transactions
{
    public interface IBuyStockService
    {
        Task<Account> BuyStock(Account buyer, string stock, int shares);
    }
}
