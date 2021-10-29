using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarWashAggregator.Review.Domain.Repositories
{
	public interface IReviewRepository
	{
		Task<Models.Entities.Review> GetReviewByIdAsync(Guid id);
		Task<IEnumerable<Models.Entities.Review>> GetReviewsByUserIdAsync(Guid userId);

		Task<IEnumerable<Models.Entities.Review>> GetReviewByCarWashId(Guid carWashId);

		Task<int> AddReviewAsync(Models.Entities.Review review);
	}
}
