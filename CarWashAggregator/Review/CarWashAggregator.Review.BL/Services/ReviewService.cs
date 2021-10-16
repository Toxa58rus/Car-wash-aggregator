using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarWashAggregator.Common.Domain.DTO.Reviews.Querys.Request;
using CarWashAggregator.Review.Domain.Interfaces;
using CarWashAggregator.Review.Domain.Repositories;

namespace CarWashAggregator.Review.BL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }


        public async Task<IEnumerable<Domain.Models.Entities.Review>> GetReviewsByUserIdAsync(Guid userId)
        {
	       return await _reviewRepository.GetReviewsByUserIdAsync(userId);
        }

        public async Task<int> AddReviewAsync(Domain.Models.Entities.Review review)
        {
	        return await _reviewRepository.AddReviewAsync(review);
        }
    }
}
