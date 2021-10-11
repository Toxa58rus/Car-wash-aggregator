using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Orders.Business.Bus.Events;
using CarWashAggregator.Orders.Domain.Contracts;
using CarWashAggregator.Orders.Domain.Entities;
using System.Threading.Tasks;

namespace CarWashAggregator.Orders.Business.Bus.EventHandlers
{
    public class OrderCreatedEventHandler : IEventHandler<OrderCreatedEvent>
    {
        private readonly IOrderRepository _dbRepository;

        public OrderCreatedEventHandler(IOrderRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public async Task Handle(OrderCreatedEvent @event)
        {
            await _dbRepository.Add(new Order()
            {
                DateReservation = @event.Order.DateReservation,
                UserId = @event.Order.UserId,
                Price = @event.Order.Price,
                СarWashId = @event.Order.СarWashId
            });
            await _dbRepository.SaveChangesAsync();
        }
    }
}
