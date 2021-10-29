using System;
using System.Linq;
using System.Threading.Tasks;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Response;
using CarWashAggregator.Review.Domain.Interfaces;

namespace CarWashAggregator.Review.BL.QueryHandlers
{
    public class GetReviewsByUserIdQueryHandler : IQueryHandler<RequestGetReviewByUserId, ResponseGetReviews>
    {
	    private readonly IReviewService _reviewService;
	    private readonly IEventBus _eventBus;


	    public GetReviewsByUserIdQueryHandler(IReviewService reviewService,IEventBus eventBus)
	    {
		    _reviewService = reviewService;
		    _eventBus = eventBus;
	    }

        public async Task<ResponseGetReviews> Handle(RequestGetReviewByUserId request)
        {
	         
	        var result = await _reviewService.GetReviewsByUserIdAsync(request.UserId);

			return new ResponseGetReviews()
			{
				Reviews = result.Select(x=>x.ToDto()).ToList()
			};
        }
    }
}
