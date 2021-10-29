using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWashAggregator.Review.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarWashAggregator.Review.Infra.Repositories
{
	public class ReviewRepository : IReviewRepository
	{
		private readonly ReviewContext _context;

		public ReviewRepository(ReviewContext context)
		{
			_context = context;
		}
		
		public async Task<Domain.Models.Entities.Review> GetReviewByIdAsync(Guid id)
		{
			return await _context.Reviews.Select(x => x).Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
		}
		public async Task<IEnumerable<Domain.Models.Entities.Review>> GetReviewsByUserIdAsync(Guid userId)
		{
			return await _context.Reviews.Select(x => x).Where(x => x.UserId == userId).AsNoTracking().ToListAsync();
		}

		public async Task<int> AddReviewAsync(Domain.Models.Entities.Review review)
		{
			await _context.Reviews.AddAsync(review);
			return await _context.SaveChangesAsync();

		}

		public async Task<IEnumerable<Domain.Models.Entities.Review>> GetReviewByCarWashId(Guid carWashId)
		{
			return await _context.Reviews.Select(x => x).Where(x => x.CarWashId == carWashId).AsNoTracking().ToListAsync();
		}
	}
}
