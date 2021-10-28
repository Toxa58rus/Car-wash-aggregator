using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base;

namespace CarWashAggregator.ApiGateway.Business.Interfaces
{
    public interface IOrderService
    {
        Task<OrderModel> GetById(Guid id);
        Task<List<OrderModel>> GetByUserId(Guid userId, string status);
        Task<List<OrderModel>> GetByCarWashId(Guid carWashId, DateTime? filterDate = null);
        Task<string[]> GetOrderStatuses();
        Task<bool> ChangeStatus(string newStatus, Guid orderId);
        Task<bool> AddOrder(OrderAdd order);
    }
}