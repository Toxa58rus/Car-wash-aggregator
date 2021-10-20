using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Domain.Contracts;
using CarWashAggregator.ApiGateway.Domain.Entities;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.ApiGateway.Business.Services
{
    public class DbLoggerService : IDbLoggerService
    {
        private readonly IApiGatewayRepository _repository;

        public DbLoggerService(IApiGatewayRepository repository)
        {
            _repository = repository;
        }

        public async Task LogMessageAsync(string message)
        {
            if (message is null)
                throw new ArgumentNullException(nameof(message), "Nothing to Log");

            await _repository.Add(new GatewayLog()
            {
                Message = message
            });
        }


    }
}
