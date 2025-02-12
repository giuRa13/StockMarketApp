using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Models
{
    public class AssetTransaction : DomainObject
    {
        public Account Account { get; set; }    
        public bool IsPurchase { get; set; }
        public Asset Asset { get; set; }
        public int SharesAmount { get; set; }
        public  DateTime DateProcessed { get; set; }
    }
}
