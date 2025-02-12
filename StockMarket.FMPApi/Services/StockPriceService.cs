using Newtonsoft.Json;
using StockMarket.Domain.Models;
using StockMarket.Domain.Services;
using StockMarket.WPF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.FMPApi.Services
{
    public class StockPriceService : IStockService
    {
        public async Task<TopStock> GetStock(string symbol)
        {
            using (FMPhttpClient client = new FMPhttpClient())
            {
                string uri = "profile/" + symbol;
                List<TopStock> topStock = await client.GetAsync<List<TopStock>>(uri);

                return topStock[0];
            }
        }

        public async Task<double> GetPrice(string symbol)
        {
            TopStock stock = await GetStock(symbol);

            return stock.price;
        }


        public async Task<ChartData> GetHistorical(string symbol, string date)
        {
            using (FMPhttpClient client = new FMPhttpClient())
            {
                string uri = "historical-price-full/ " + symbol + "?from=" + date;
                ChartData stock = await client.GetAsyncB<ChartData>(uri);

                return stock;
            }
        }
    }
}
