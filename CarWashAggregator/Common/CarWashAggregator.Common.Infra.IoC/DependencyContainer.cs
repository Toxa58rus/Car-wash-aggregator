using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Infra.Bus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarWashAggregator.Common.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterBusService(IServiceCollection services)
        {
            services.AddTransient<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(scopeFactory);
            });


        }
    }
}
