using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarWashAggregator.Review.Domain.Interfaces
{
    public interface IReviewService
    {
	    Task<IEnumerable<Domain.Models.Entities.Review>> GetReviewByCarWashId(Guid carWashId);


        Task<IEnumerable<Models.Entities.Review>> GetReviewsByUserIdAsync(Guid userId);

        Task<int> AddReviewAsync(Models.Entities.Review review);

        Task<Domain.Models.Entities.Review> GetReviewByIdAsync(Guid Id);
    }
}
