using System;
using System.Collections.Generic;
using System.Text;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Request
{
	public class RequestCreateReviewDtoQuery : Query
	{
		public Guid UserId { get; set; }

		public Guid CarWashId { get; set; }

		public string Body { get; set; }

		public double Rating { get; set; }
	}
}
