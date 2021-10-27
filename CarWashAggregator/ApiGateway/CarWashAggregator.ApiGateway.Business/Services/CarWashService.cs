using System;
using System.Globalization;
using AutoMapper;
using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Response;
using System.Threading.Tasks;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;
using CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Response;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Response;


namespace CarWashAggregator.ApiGateway.Business.Services
{
    public class CarWashService : ICarWashService
    {
        private readonly IEventBus _bus;
        private readonly IMapper _mapper;

        public CarWashService(IMapper mapper, IEventBus bus)
        {
            _mapper = mapper;
            _bus = bus;
        }

        public async Task<SearchWashesResult> SearchAsync(CarWashSearch query)
        {
            var filters = _mapper.Map<RequestCarWashByFilters>(query);
            var response =
                await _bus.RequestQuery<RequestCarWashByFilters, ResponseCarWashSearchByFilters>(filters);

            var result = response is null ? null : _mapper.Map<SearchWashesResult>(response);
            return result;
        }
        public async Task<GetWashResult> GetById(Guid id, bool includeOrders = false)
        {
            var result = new GetWashResult();
            var responseWash =
                await _bus.RequestQuery<RequestGetCarWashById, ResponseGetCarWashById>(new RequestGetCarWashById { Id = id });
            var carWash = responseWash.Wash;
            result.Wash = _mapper.Map<CarWashModel>(carWash);

            var responseReview = await _bus.RequestQuery<RequestGetReviewsByCarWashId, ResponseGetReviews>(
                new RequestGetReviewsByCarWashId { CarWashId = carWash.Id });

            foreach (var review in responseReview.Reviews)
            {
                var user = await _bus.RequestQuery<RequestGetUserByUserId, ResponseGetUser>(
                    new RequestGetUserByUserId { UserId = review.UserId });

                result.Comments.Add(new CommentModel
                {
                    User =  {
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    },
                    Date = review.PostedAt.ToLongDateString(),
                    Rating = review.Rating.ToString(CultureInfo.CurrentCulture),
                    Comment = review.Body
                });
            }

            if (includeOrders)
            {
                //await _bus.RequestQuery<RequestGetUserByUserId, ResponseGetUser>(new RequestGetUserByUserId { UserId = review.Reviews })
            }
            
            return result;
        }

    }
}
