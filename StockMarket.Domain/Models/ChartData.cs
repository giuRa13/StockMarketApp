using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Models
{
    public class ChartData
    {
        public string symbol { get; set; }
        public List<Historical> historical { get; set; }
    }

    public class Historical
    {
        public string date { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double close { get; set; }
        public double adjClose { get; set; }
        public int volume { get; set; }
        public int unadjustedVolume { get; set; }
        public double change { get; set; }
        public double changePercent { get; set; }
        public double vwap { get; set; }
        public string label { get; set; }
        public double changeOverTime { get; set; }
    }
}
