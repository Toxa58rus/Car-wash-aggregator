using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;

namespace CarWashAggregator.ApiGateway.Business.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewModel> GetById(Guid id);
        Task<List<ReviewModel>> GetByUserId(Guid userId);
        Task<List<ReviewModel>> GetByCarWashId(Guid carWashId);
        Task<bool> AddReview(ReviewAdd review);
    }
}