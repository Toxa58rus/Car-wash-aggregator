using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarWashAggregator.User.Domain.Contracts;
using CarWashAggregator.User.Infa.Repository;
using CarWashAggregator.User.Infa.Data;
using Microsoft.EntityFrameworkCore;
using CarWashAggregator.Common.Infra;
using CarWashAggregator.Common.Domain.Contracts;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using CarWashAggregator.User.Domain.interfaces;
using CarWashAggregator.User.Business.Services;
using System;
using CarWashAggregator.User.Business.EventHandlers;
using CarWashAggregator.User.Business.QueryHandlers;
using CarWashAggregator.Common.Domain.DTO.User.Events;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Response;

namespace CarWashAggregator.User.Deamon
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<UserContext>(options => options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")));
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUserRepository, UserReposirory>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<UserRegisteredEventHandler>();
            services.AddTransient<GetUserByAuthIdQueryHandler>();
            services.AddTransient<GetUserByUserIdQueryHandler>();
            //services.AddTransient<UpdateUserEventHandler>();

            services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic)); ;

            BusContainer.RegisterBusService(services, _configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.SubscribeToQuery<RequestGetUserByAuthId, ResponseGetUser, GetUserByAuthIdQueryHandler>();
            eventBus.SubscribeToQuery<RequestGetUserByUserId, ResponseGetUser, GetUserByUserIdQueryHandler>();

            eventBus.SubscribeToEvent<UserRegisteredEvent, UserRegisteredEventHandler>();
            //eventBus.SubscribeToEvent<UpdateUserEvent, UpdateUserEventHandler>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
