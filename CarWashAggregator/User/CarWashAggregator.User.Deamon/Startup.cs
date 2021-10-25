using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CarWashAggregator.User.Domain;
using CarWashAggregator.User.Domain.Contracts;
using CarWashAggregator.User.Infa.Repository;
using CarWashAggregator.User.Infa.Data;
using Microsoft.EntityFrameworkCore;
using CarWashAggregator.Orders.Business.Services;
using CarWashAggregator.Common.Infra;
using CarWashAggregator.Orders.Business.QueryHandlers;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Response;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Request;
using CarWashAggregator.Orders.Business.EventHandlers;
using CarWashAggregator.Common.Domain.DTO.User.Events;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using CarWashAggregator.User.Domain.interfaces;

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

            services.AddScoped<IUserRepository, UserReposirory>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<CreateUserQueryHandler>();
            //services.AddTransient<GetUserByIdQueryHandler>();
            services.AddTransient<DeleteUserByIdEventHandler>();
            services.AddTransient<UpdateUserEventHandler>();

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

            eventBus.SubscribeToQuery<RequestRoleIdByUserIdQuery, ResponseCreateUserQuery, CreateUserQueryHandler>();
            //eventBus.SubscribeToQuery<RequestGetUserByIdQuery, ResponseGetUserByIdQuery, GetUserByIdQueryHandler>();

            eventBus.SubscribeToEvent<DeleteUserByIdEvent, DeleteUserByIdEventHandler>();
            eventBus.SubscribeToEvent<UpdateUserEvent, UpdateUserEventHandler>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
