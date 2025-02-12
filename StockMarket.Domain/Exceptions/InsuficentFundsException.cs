using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.Domain.Exceptions
{
    public class InsuficentFundsException : Exception
    {
        public double AccountBalance { get; set; }
        public double RequireBalance { get; set; }

        public InsuficentFundsException(double accountBalance, double requireBalance) 
        {
            AccountBalance = accountBalance;
            RequireBalance = requireBalance;
        }

        public InsuficentFundsException(double accountBalance, double requireBalance, string message) : base(message)
        {
            AccountBalance = accountBalance;
            RequireBalance = requireBalance;
        }

        public InsuficentFundsException(double accountBalance, double requireBalance, string message, Exception innerException) : base(message, innerException)
        {
            AccountBalance = accountBalance;
            RequireBalance = requireBalance;
        }
    }
}
