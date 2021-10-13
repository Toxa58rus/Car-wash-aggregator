using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Order.Events;
using CarWashAggregator.Orders.Domain.Contracts;
using CarWashAggregator.Orders.Domain.Entities;
using System.Threading.Tasks;

namespace CarWashAggregator.Orders.Business.Handlers.EventHandlers
{
    public class OrderCreatedEventHandler : IEventHandler<OrderCreated>
    {
        private readonly IOrderRepository _dbRepository;

        public OrderCreatedEventHandler(IOrderRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task Handle(OrderCreated @event)
        {
            await _dbRepository.Add(new Order()
            {
                DateReservation = @event.DateReservation,
                UserId = @event.UserId,
                Price = @event.Price,
                СarWashId = @event.СarWashId
            });
            await _dbRepository.SaveChangesAsync();
        }
    }
}
