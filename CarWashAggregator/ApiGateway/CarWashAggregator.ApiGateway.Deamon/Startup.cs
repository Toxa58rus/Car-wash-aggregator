using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Business.Services;
using CarWashAggregator.ApiGateway.Domain.Contracts;
using CarWashAggregator.ApiGateway.Infra.Data;
using CarWashAggregator.ApiGateway.Infra.Repository;
using CarWashAggregator.Common.Domain;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarWashAggregator.ApiGateway.Deamon
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
            services.AddDbContext<ApiGatewayContext>(options =>
            {
                options.UseNpgsql(_configuration.GetConnectionString(Helper.DataBaseConnectionSection));
            });

            //Services
            services.AddTransient<IAuthService, AuthService>()
                .AddTransient<IDbLoggerService, DbLoggerService>();

            //Data
            services.AddScoped<IApiGatewayRepository, ApiGatewayRepository>();

            //Subscriptions
            //services.AddTransient<>();

            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
            BusContainer.RegisterBusService(services, _configuration);

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
            //eventBus.SubscribeToQuery<, , >();
        }
    }
}
