using CarWashAggregator.Authorization.Business.Handlers.QueryHandlers;
using CarWashAggregator.Authorization.Business.JwtAuth.Contracts;
using CarWashAggregator.Authorization.Business.JwtAuth.Implementation;
using CarWashAggregator.Authorization.Business.JwtAuth.Models;
using CarWashAggregator.Authorization.Domain.Contracts;
using CarWashAggregator.Authorization.Infra.Data;
using CarWashAggregator.Authorization.Infra.Repository;
using CarWashAggregator.Common.Domain;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Authorization.Querys.Response;
using CarWashAggregator.Common.Infra;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarWashAggregator.Authorization.Deamon
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
            var jwtTokenConfig = _configuration.GetSection(Helper.JwtSection).Get<JwtTokenConfig>();
            services.AddSingleton(jwtTokenConfig);
            services.AddScoped<IAuthorizationManager, AuthorizationManager>();

            services.AddDbContext<AuthorizationContext>(options =>
            {
                options.UseNpgsql(_configuration.GetConnectionString(Helper.DataBaseConnectionSection));
            });

            //Data
            services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();

            //Subscriptions
            services.AddTransient<ValidationCheckHandler>();

            services.AddMvc();
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

            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.SubscribeToQuery<RequestValidationCheck, ResponseValidationCheck, ValidationCheckHandler>();
        }
    }
}