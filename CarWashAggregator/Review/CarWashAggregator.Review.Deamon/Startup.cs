using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWashAggregator.Common.Domain;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Response;
using CarWashAggregator.Common.Infra;
using CarWashAggregator.Review.BL.QueryHandlers;
using CarWashAggregator.Review.BL.Services;
using CarWashAggregator.Review.Domain.Interfaces;
using CarWashAggregator.Review.Domain.Repositories;
using CarWashAggregator.Review.Infra;
using CarWashAggregator.Review.Infra.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarWashAggregator.Review.Deamon
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		private readonly IConfiguration _configuration;

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ReviewContext>(options =>
			{
				options.UseNpgsql(_configuration.GetConnectionString(Helper.DataBaseConnectionSection));
			});

			services.AddScoped<IReviewService, ReviewService>();
			services.AddScoped<IReviewRepository, ReviewRepository>();

			
			services.AddTransient<CreateReviewQueryHandler>();
			services.AddTransient<GetReviewByCarWashIdHandler>();
			services.AddTransient<GetReviewByIdHandler>();
			services.AddTransient<GetReviewsByUserIdQueryHandler>();

			BusContainer.RegisterBusService(services, _configuration);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

			eventBus.SubscribeToQuery<RequestCreateReviewDtoQuery, ResponseCreateReviewDtoQuery, CreateReviewQueryHandler>();
			eventBus.SubscribeToQuery<RequestGetReviewByCarWashId, ResponseGetReviews, GetReviewByCarWashIdHandler>();
			eventBus.SubscribeToQuery<RequestGetReviewById, ResponseGetReview, GetReviewByIdHandler>();
			eventBus.SubscribeToQuery<RequestGetReviewByUserId, ResponseGetReviews, GetReviewsByUserIdQueryHandler>();
		}
	}
}
