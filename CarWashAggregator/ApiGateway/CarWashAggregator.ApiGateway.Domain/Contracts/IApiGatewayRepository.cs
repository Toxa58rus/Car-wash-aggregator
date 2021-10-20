using CarWashAggregator.ApiGateway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashAggregator.ApiGateway.Domain.Contracts
{
    public interface IApiGatewayRepository
    {
        IQueryable<T> Get<T>() where T : class, IEntity;
        Task<Guid> Add<T>(T newEntity) where T : class, IEntity;
        Task AddRange<T>(IEnumerable<T> newEntities) where T : class, IEntity;


        Task Remove<T>(T entity) where T : class, IEntity;
        Task RemoveRange<T>(IEnumerable<T> entities) where T : class, IEntity;

        Task Update<T>(T entity) where T : class, IEntity;
        Task UpdateRange<T>(IEnumerable<T> entities) where T : class, IEntity;

        Task<int> SaveChangesAsync();
    }
}
