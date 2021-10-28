using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWashAggregator.CarWashes.Domain.Interfaces;
using CarWashAggregator.CarWashes.BL.Services;
using CarWashAggregator.CarWashes.Domain.Repositories;
using CarWashAggregator.CarWashes.Infra;
using CarWashAggregator.CarWashes.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CarWashAggregator.Common.Infra;
using CarWashAggregator.CarWashes.BL.QueryHandlers;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Response;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using CarWashAggregator.Common.Domain.DTO.CarWash.Events;
using CarWashAggregator.CarWashes.BL.EventHandlers;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys;

namespace CarWashAggregator.CarWashes.Deamon
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(_config.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddTransient<ICarWashRepository, CarWashRepository>();
            services.AddTransient<ICarWashService, CarWashService>();

            services.AddTransient<DeleteCarWashEventHandler>();
            services.AddTransient<UpdateCarWashEventHandler>();
            services.AddTransient<UpdateCarWashRatingEventHandler>();

            services.AddTransient<CarWashSearchByFilterQueryHandler>();
            services.AddTransient<GetCarWashQueryHandler>();
            services.AddTransient<GetCarWashByUserIdQueryHandler>();
            services.AddTransient<CreateCarWashQueryHandler>();
            services.AddTransient<GetCarWashesPaginatedQueryHandler>();

            services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic));

            BusContainer.RegisterBusService(services, _config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.SubscribeToEvent<DeleteCarWashEvent, DeleteCarWashEventHandler>();
            eventBus.SubscribeToEvent<UpdateCarWashEvent, UpdateCarWashEventHandler>();
            eventBus.SubscribeToEvent<UpdateCarWashRatingEvent, UpdateCarWashRatingEventHandler>();

            eventBus.SubscribeToQuery<RequestCarWashByFilters, ResponseCarWashSearchByFilters, CarWashSearchByFilterQueryHandler>();
            eventBus.SubscribeToQuery<RequestGetCarWashById, ResponseGetCarWashById, GetCarWashQueryHandler>();
            eventBus.SubscribeToQuery<RequestGetCarWashByUserId, ResponseGetCarWashByUserId, GetCarWashByUserIdQueryHandler>();
            eventBus.SubscribeToQuery<RequestCreateCarWashQuery, ResponseCreateCarWashQuery, CreateCarWashQueryHandler>();
            eventBus.SubscribeToQuery<RequestGetCarWashesPaginatedQuery, ResponseGetCarWashesPaginatedQuery, GetCarWashesPaginatedQueryHandler>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
