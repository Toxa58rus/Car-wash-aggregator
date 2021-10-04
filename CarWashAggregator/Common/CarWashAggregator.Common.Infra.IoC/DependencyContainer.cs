using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Infra.Bus;
using CarWashAggregator.Orders.Business.EventHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarWashAggregator.Common.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(scopeFactory, configuration);
            });

            //Subscriptions
            services.AddTransient<OrderCreatedEventHandler>();

        }
    }
}
