using StockMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Services
{
    public interface IStockService
    {
        Task<TopStock> GetStock(string symbol);

        Task<double> GetPrice(string symbol);
        Task<ChartData> GetHistorical(string symbol, string date);
    }
}
