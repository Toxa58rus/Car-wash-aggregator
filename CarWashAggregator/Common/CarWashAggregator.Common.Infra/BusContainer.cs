﻿using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Infra.Bus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarWashAggregator.Common.Infra
{
    public class BusContainer
    {
        public static void RegisterBusService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(scopeFactory, configuration);
            });
        }
    }
}
