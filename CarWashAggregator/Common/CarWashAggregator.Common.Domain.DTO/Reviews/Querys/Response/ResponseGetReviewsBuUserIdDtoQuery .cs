using System;
using System.Collections.Generic;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Response
{
	public class ResponseGetReviewsBuUserIdDtoQuery : Query
	{
		public IEnumerable<ReviewDto> Reviews { get; set; }
	}
}
