﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Models
{
    public class Asset
    {
        public string Symbol { get; set; }
        public double PricePerShare {  get; set; }

    }
}
