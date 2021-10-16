using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarWashAggregator.Review.Domain.Repositories
{
	public interface IReviewRepository
	{
		Task<IEnumerable<Models.Entities.Review>> GetReviewsByUserIdAsync(Guid userId);

		Task<int> AddReviewAsync(Models.Entities.Review review);
	}
}
