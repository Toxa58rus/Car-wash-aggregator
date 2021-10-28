using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.Order.Querys.Response;
using CarWashAggregator.Orders.Domain.Contracts;
using CarWashAggregator.Orders.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Internal;

namespace CarWashAggregator.Orders.Business.Handlers.QueryHandlers
{
    public class RequestStatusesHandler : IQueryHandler<RequestStatuses, ResponseStatuses>
    {
        private readonly IOrderRepository _dbRepository;

        public RequestStatusesHandler(IOrderRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public Task<ResponseStatuses> Handle(RequestStatuses request)
        {
            var statuses = _dbRepository.Get<Status>().Select(s=>s.Name);

            return Task.FromResult(new ResponseStatuses(){Statuses = statuses.ToArray()});
        }
    }
}
