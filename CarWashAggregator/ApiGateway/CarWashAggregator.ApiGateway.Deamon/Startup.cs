using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Business.Services;
using CarWashAggregator.ApiGateway.Deamon.Middleware;
using CarWashAggregator.ApiGateway.Domain.Contracts;
using CarWashAggregator.ApiGateway.Infra.Data;
using CarWashAggregator.ApiGateway.Infra.Repository;
using CarWashAggregator.Common.Domain;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Infra;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
            services.AddTransient<IDbLoggerService, DbLoggerService>()
                .AddScoped<IAuthService,AuthService>();
 
            //Data
            services.AddScoped<IApiGatewayRepository, ApiGatewayRepository>();

            //Subscriptions
            //services.AddTransient<>();
/*
            services.AddMvcCore(options =>
            {
	            options.RequireHttpsPermanent = true;
	            options.RespectBrowserAcceptHeader = true;
            }).AddFormatterMappings(); */
			//services.AddControllers().AddNewtonsoftJson();
	            //.AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

	            services.AddMvc().AddNewtonsoftJson();
            //    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddCors(options => options.AddDefaultPolicy(
	            builder =>
	            {
		            builder//.WithOrigins("http://89.108.65.74", "http://localhost:5000")
			            .AllowAnyHeader()
			            .AllowAnyMethod()
			            .AllowAnyOrigin();
	            }));
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
            app.UseCors();
            app.UseMiddleware<JwtMiddleware>();
            ConfigureEventBus(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();//.RequireCors("MyPolicy");
            });
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            //eventBus.SubscribeToQuery<, , >();
        }
    }
}
