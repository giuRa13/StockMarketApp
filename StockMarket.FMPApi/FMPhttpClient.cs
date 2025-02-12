using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StockMarket.WPF
{
    public class FMPhttpClient :HttpClient
    {
        public FMPhttpClient() 
        {
            this.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/");
        }


        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await GetAsync($"{uri}/?apikey=vTzirAVlYuLErLtb6lcjwcW3cybPTTBk");
            string jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }

        public async Task<T> GetAsyncB<T>(string uri)
        {
            HttpResponseMessage response = await GetAsync($"{uri}/&apikey=vTzirAVlYuLErLtb6lcjwcW3cybPTTBk");
            string jsonResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }

    }
}
