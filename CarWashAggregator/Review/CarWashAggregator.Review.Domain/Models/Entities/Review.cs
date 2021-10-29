using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.Review.Domain.Models.Entities
{
	public class Review
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public Guid carWashId { get; set; }
		public string Body { get; set; }
		public double Rating { get; set; }
	};
	
}
