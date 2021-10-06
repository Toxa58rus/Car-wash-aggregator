using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Orders.Business.Events;
using CarWashAggregator.Orders.Domain.Contracts;
using CarWashAggregator.Orders.Domain.Entities;
using System.Threading.Tasks;

namespace CarWashAggregator.Orders.Business.EventHandlers
{
    public class OrderCreatedEventHandler : IEventHandler<OrderCreatedEvent>
    {
        private readonly IOrderRepository _dbRepository;

        public OrderCreatedEventHandler(IOrderRepository DbRepository)
        {
            _dbRepository = DbRepository;
        }

        public async Task Handle(OrderCreatedEvent @event)
        {
            await _dbRepository.Add(new Order()
            {
                DateReservation = @event.order.DateReservation,
                UserId = @event.order.UserId,
                Price = @event.order.Price,
                СarWashId = @event.order.СarWashId
            });
            await _dbRepository.SaveChangesAsync();
        }
    }
}
