using System;
using System.Collections.Generic;
using System.Text;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Response
{
	public class ResponseCreateReviewDtoQuery : Query
	{
		public bool Result { get; set; }
	}
}
