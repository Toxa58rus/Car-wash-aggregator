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
    public class GetReviewByIdHandler : IQueryHandler<RequestGetReviewById, ResponseGetReview>
    {
	    private readonly IReviewService _reviewService;


	    public GetReviewByIdHandler(IReviewService reviewService)
	    {
		    _reviewService = reviewService;
	    }

        public async Task<ResponseGetReview> Handle(RequestGetReviewById request)
        {
	        var result = await _reviewService.GetReviewByIdAsync(request.Id);

	        return new ResponseGetReview() {Review = result.ToDto()};

        }
    }
}
