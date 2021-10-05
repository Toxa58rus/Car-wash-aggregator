using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Infra.IoC;
using CarWashAggregator.Orders.Business.EventHandlers;
using CarWashAggregator.Orders.Business.Interfaces;
using CarWashAggregator.Orders.Business.Services;
using CarWashAggregator.Orders.Domain.Contracts;
using CarWashAggregator.Orders.Events;
using CarWashAggregator.Orders.Infra.Data;
using CarWashAggregator.Orders.Infra.Repository;
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
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<OrderContext>(options =>
            {
                options.UseNpgsql(_configuration.GetConnectionString("DataBase"));
            });

            //Services
            services.AddTransient<IOrderService, OrderService>();

            //Data
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<OrderContext>();

            RegisterServices(services);

        }
        private void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services, _configuration);
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
