﻿using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Domain.Contracts;
using System;
using System.Threading.Tasks;
using CarWashAggregator.ApiGateway.Domain.Models.Entities;

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
                throw new ArgumentNullException(nameof(message), "Nothing to Log :C");

            await _repository.Add(new GatewayLog()
            {
                Message = message
            });
        }


    }
}
