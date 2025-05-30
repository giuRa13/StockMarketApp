﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using StockMarket.Domain.Models;
using StockMarket.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace StockMarket.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly DesignTimeDbContextFactory _dbContextFactory;
        private readonly CommonDataService<T> _commonDataService;
        public GenericDataService(DesignTimeDbContextFactory dbContextFactory) 
        { 
            _dbContextFactory = dbContextFactory;
            _commonDataService = new CommonDataService<T>(dbContextFactory);
        }
        

        public async Task<T> Create(T entity)
        {
            return await _commonDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _commonDataService.Delete(id);
        }

        public async Task<T> Update(int id, T entity)
        {
            return await _commonDataService.Update(id, entity);
        }

        public async Task<T> Get(int id)
        {
            using (StockMarketDbContext context = _dbContextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);

                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (StockMarketDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();

                return entities;
            }
        }

        

    }

}
