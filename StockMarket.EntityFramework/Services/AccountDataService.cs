using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using StockMarket.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockMarket.Domain.Models;

namespace StockMarket.EntityFramework.Services
{
    public class AccountDataService : IDataService<Account>
    {

        private readonly DesignTimeDbContextFactory _dbContextFactory;
        private readonly CommonDataService<Account> _commonDataService;

        public AccountDataService(DesignTimeDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _commonDataService = new CommonDataService<Account>(dbContextFactory);
        }


        public async Task<Account> Create(Account entity)
        {
            return await _commonDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _commonDataService.Delete(id);
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await _commonDataService.Update(id, entity);
        }

        public async Task<Account> Get(int id)
        {
            using (StockMarketDbContext context = _dbContextFactory.CreateDbContext())
            {
                Account entity = await context.Accounts.Include(a => a.AssetTransactions).FirstOrDefaultAsync((e) => e.Id == id);

                return entity;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (StockMarketDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<Account> entities = await context.Accounts.Include(a => a.AssetTransactions).ToListAsync();

                return entities;
            }
        }

    
    }
}
