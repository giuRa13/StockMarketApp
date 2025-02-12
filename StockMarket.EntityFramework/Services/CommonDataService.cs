using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using StockMarket.Domain.Models;

namespace StockMarket.EntityFramework.Services
{
    public class CommonDataService<T> where T : DomainObject
    {

        private readonly DesignTimeDbContextFactory _dbContextFactory;

        public CommonDataService(DesignTimeDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }


        public async Task<T> Create(T entity)
        {
            using (StockMarketDbContext context = _dbContextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (StockMarketDbContext context = _dbContextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (StockMarketDbContext context = _dbContextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }


    }

}
