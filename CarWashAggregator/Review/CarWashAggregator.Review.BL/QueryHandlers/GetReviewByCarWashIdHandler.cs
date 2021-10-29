using System;
using System.Linq;
using System.Threading.Tasks;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.CarWash.Events;
using CarWashAggregator.Common.Domain.DTO.Reviews;
using CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Response;
using CarWashAggregator.Review.Domain.Interfaces;

namespace CarWashAggregator.Review.BL.QueryHandlers
{
    public class GetReviewByCarWashIdHandler : IQueryHandler<RequestGetReviewByCarWashId, ResponseGetReviews>
    {
	    private readonly IReviewService _reviewService;


	    public GetReviewByCarWashIdHandler(IReviewService reviewService)
	    {
		    _reviewService = reviewService;
	    }

        public async Task<ResponseGetReviews> Handle(RequestGetReviewByCarWashId request)
        {
	        var result = await _reviewService.GetReviewByCarWashId(request.CarWashId);

			return new ResponseGetReviews() { Reviews = result.Select(x=> x.ToDto()).ToList()};
	        
        }
    }
}
