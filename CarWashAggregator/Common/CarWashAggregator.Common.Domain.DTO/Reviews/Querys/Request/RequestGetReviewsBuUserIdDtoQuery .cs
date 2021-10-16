using System;
using System.Collections.Generic;
using System.Text;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Request
{
	public class RequestGetReviewsBuUserIdDtoQuery : Query
	{
		public Guid UserId { get; set; }
	}
}
