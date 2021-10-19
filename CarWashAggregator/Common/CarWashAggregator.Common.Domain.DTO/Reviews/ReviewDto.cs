using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.Common.Domain.DTO.Reviews
{
	public class ReviewDto
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public Guid СarWashId { get; set; }
		public string Body { get; set; }
		public double Rating { get; set; }
	}
}
