using System;
using System.Linq;
using System.Threading.Tasks;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.CarWash.Events;
using CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Response;
using CarWashAggregator.Review.Domain.Interfaces;

namespace CarWashAggregator.Review.BL.QueryHandlers
{
    public class CreateReviewQueryHandler : IQueryHandler<RequestCreateReviewDtoQuery, ResponseCreateReviewDtoQuery>
    {
	    private readonly IReviewService _reviewService;
	    private readonly IEventBus _eventBus;


	    public CreateReviewQueryHandler(IReviewService reviewService,IEventBus eventBus)
	    {
		    _reviewService = reviewService;
		    _eventBus = eventBus;
	    }

        public async Task<ResponseCreateReviewDtoQuery> Handle(RequestCreateReviewDtoQuery request)
        {

	        var count = await _reviewService.AddReviewAsync(request.ToModel());
	        
	        var result = await _reviewService.GetReviewsByUserIdAsync(request.UserId);

	        double avgRating = result.Average(x => x.Rating);

			_eventBus.PublishEvent(
		        new UpdateCarWashRatingEvent()
		        {
			        CarWashId = request.CarWashId,
			        AVG_Rating = avgRating
				}
	        );

			return new ResponseCreateReviewDtoQuery() { Result = count > 0 ? true : false};
	        
        }
    }
}
