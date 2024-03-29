﻿using CarWashAggregator.Authorization.Domain.Contracts;
using CarWashAggregator.Authorization.Domain.Entities;
using CarWashAggregator.Authorization.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CarWashAggregator.Authorization.Infra.Repository
{
    public class AuthorizationRepository : IAuthorizationRepository
    {
        private readonly AuthorizationDbContext _dbContext;

        public AuthorizationRepository(AuthorizationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Get<T>() where T : class, IEntity
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public async Task<Guid> Add<T>(T newEntity) where T : class, IEntity
        {
            var entity = await _dbContext.Set<T>().AddAsync(newEntity);
            return entity.Entity.Id;
        }

        public async Task AddRange<T>(IEnumerable<T> newEntities) where T : class, IEntity
        {
            await _dbContext.Set<T>().AddRangeAsync(newEntities);
        }

        public Task Remove<T>(T entity) where T : class, IEntity
        {
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public Task RemoveRange<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            _dbContext.Set<T>().RemoveRange(entities);
            return Task.CompletedTask;

        }

        public Task Update<T>(T entity) where T : class, IEntity
        {
            _dbContext.Set<T>().Update(entity);
            return Task.CompletedTask;

        }

        public Task UpdateRange<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            _dbContext.Set<T>().UpdateRange(entities);
            return Task.CompletedTask;

        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}