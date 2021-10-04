using CarWashAggregator.Orders.Domain.Contracts;
using CarWashAggregator.Orders.Domain.Models;
using CarWashAggregator.Orders.Events;
using System.Threading.Tasks;

namespace CarWashAggregator.Orders.Business.EventHandlers
{
    public class OrderCreatedEventHandler : IEventHandler<OrderCreatedEvent>
    {
        private readonly IDbRepository _dbRepository;

        public OrderCreatedEventHandler(IDbRepository DbRepository)
        {
            _dbRepository = DbRepository;
        }

        public async Task Handle(OrderCreatedEvent @event)
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
