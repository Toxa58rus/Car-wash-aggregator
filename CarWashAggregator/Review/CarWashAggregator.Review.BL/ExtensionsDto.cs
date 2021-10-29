using System;
using CarWashAggregator.Common.Domain.DTO.Reviews;
using CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Request;

namespace CarWashAggregator.Review.BL
{
	public static class ExtensionsDto
	{
		public static Domain.Models.Entities.Review ToModel(this RequestCreateReviewDtoQuery reviewQuery)
		{
			return new Domain.Models.Entities.Review()
			{
				Id = Guid.NewGuid(),
				Body = reviewQuery.Body,
				Rating = reviewQuery.Rating,
				CarWashId = reviewQuery.CarWashId,
				UserId = reviewQuery.UserId
			};
		}

		public static ReviewDto ToDto(this Domain.Models.Entities.Review model)
		{
	
			return new ReviewDto()
			{
				Id = model.Id ,
				Body = model.Body,
				Rating = model.Rating,
				CarWashId = model.CarWashId,
				UserId = model.UserId
			};
		}

		
	}
}
