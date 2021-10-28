using AutoMapper;
using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Response;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Response;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Response;

namespace CarWashAggregator.ApiGateway.Business.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IEventBus _bus;
        private readonly IMapper _mapper;
        private readonly ILogger<ReviewService> _logger;

        public ReviewService(IMapper mapper, IEventBus bus, ILogger<ReviewService> logger)
        {
            _mapper = mapper;
            _bus = bus;
            _logger = logger;
        }

        public async Task<ReviewModel> GetById(Guid id)
        {
            var result =
                await _bus.RequestQuery<RequestGetReviewById,ResponseGetReview>(new RequestGetReviewById()
                { Id = id });

            return _mapper.Map<ReviewModel>(result.Review);
        }

        public async Task<List<ReviewModel>> GetByUserId(Guid userId)
        {
            var result =
                await _bus.RequestQuery<RequestGetReviewByUserId, ResponseGetReviews>(new RequestGetReviewByUserId
                {
                    UserId = userId
                });

            return _mapper.Map<List<ReviewModel>>(result.Reviews);
        }
        public async Task<List<ReviewModel>> GetByCarWashId(Guid carWashId)
        {
            var result =
                await _bus.RequestQuery<RequestGetReviewByCarWashId, ResponseGetReviews>(new RequestGetReviewByCarWashId
                {
                    CarWashId = carWashId
                });

            return _mapper.Map<List<ReviewModel>>(result.Reviews);
        }
     
        public async Task<bool> AddReview(ReviewAdd review)
        {
            RequestCreateReviewDtoQuery request;
            try
            {
               request = _mapper.Map<RequestCreateReviewDtoQuery>(review);
            }
            catch {
                _logger.LogError("cannot map OrderModel to RequestSaveOrder");
                throw;
            }
          
            var result =
                await _bus.RequestQuery<RequestCreateReviewDtoQuery, ResponseCreateReviewDtoQuery>(request);
            return result?.Result ?? false;
        }
    }
}
