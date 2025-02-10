using StockMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Services
{
    public interface ITopStocksService
    {
        Task<TopStock> GetStockFull(TopStockName ticker);
    }
}
