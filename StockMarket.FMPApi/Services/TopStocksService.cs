using Newtonsoft.Json;
using StockMarket.Domain.Models;
using StockMarket.Domain.Services;
using StockMarket.WPF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StockMarket.FMPApi.Services
{
    public class TopStocksService : ITopStocksService
    {

        public async Task<TopStock> GetStockFull(TopStockName ticker)
        {
            /*using (HttpClient client = new HttpClient())
            {
                //HttpResponseMessage response = await client.GetAsync("https://financialmodelingprep.com/api/v3/quote/AAPL,NVDA,MSFT/?apikey=vTzirAVlYuLErLtb6lcjwcW3cybPTTBk");
                string url = "https://financialmodelingprep.com/api/v3/profile/" + GetUriSuffix(ticker) + "/?apikey=vTzirAVlYuLErLtb6lcjwcW3cybPTTBk";
                var httpResponse = await client.GetAsync(url);
                string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                List<TopStock> topStock = JsonConvert.DeserializeObject<List<TopStock>>(jsonResponse);

                return topStock[0];
            }*/

            using (FMPhttpClient client = new FMPhttpClient()) 
            {
                string uri = "profile/" + GetUriSuffix(ticker);
                List<TopStock> topStock = await client.GetAsync<List<TopStock>>(uri);

                return topStock[0];
            }
        }

        public string GetUriSuffix(TopStockName ticker) 
        {
            switch (ticker)
            {
                case TopStockName.AAPL:
                    return "AAPL";
                case TopStockName.NVDA:
                    return "NVDA";
                case TopStockName.MSFT:
                    return "MSFT";
                case TopStockName.AMZN:
                    return "AMZN";
                default:
                    throw new Exception("TopStockName does not have a suffix defined.");
            }
        }


    }
}
