using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Infra;
using CarWashAggregator.Files.BL.Services;
using CarWashAggregator.Files.Domain.Interfaces;
using CarWashAggregator.Files.Domain.Repositories;
using CarWashAggregator.Files.Infra;
using CarWashAggregator.Files.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarWashAggregator.Files.Deamon
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
            services.AddMvc();

            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(_config.GetConnectionString("DefaultConnection")));

            services.AddTransient<IFileRepository, FileRepository>();
            services.AddTransient<IFileService, FileService>();

            BusContainer.RegisterBusService(services, _config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
