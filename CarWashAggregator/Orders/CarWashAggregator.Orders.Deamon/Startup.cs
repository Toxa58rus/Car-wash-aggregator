using CarWashAggregator.Orders.Business.Interfaces;
using CarWashAggregator.Orders.Business.Services;
using CarWashAggregator.Orders.Domain.Contracts;
using CarWashAggregator.Orders.Domain.EventHandlers;
using CarWashAggregator.Orders.Infra.Bus;
using CarWashAggregator.Orders.Infra.Context;
using CarWashAggregator.Orders.Infra.Repository;
using CarWashAggregator.Orders.Orders.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarWashAggregator.Orders.Deamon
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql("ConnectionString");
            });

            services.AddTransient<IEventBus, RabbitMQBus>(sp =>
            {
                var scopeFactory = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(scopeFactory);
            });


            services.AddMvc();

            //Subscriptions
            services.AddTransient<OrderCreatedEventHandler>();

            //Services
            services.AddTransient<IOrderService, OrderService>();

            //Data
            services.AddTransient<IDbRepository, DbRepository>();
            services.AddTransient<DataContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            ConfigureEventBus(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<OrderCreatedEvent, OrderCreatedEventHandler>();
        }
    }
}
