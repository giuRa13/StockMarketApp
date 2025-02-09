using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarket.EntityFramework
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StockMarketDbContext>
    {
        public StockMarketDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<StockMarketDbContext>();
            options.UseSqlServer("Server=GIULI13\\SQLEXPRESS;Initial Catalog=StockMarketDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new StockMarketDbContext(options.Options);
        }
    }
}
