using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Events;

namespace CarWashAggregator.Orders.Business.Bus.Events
{
    public class OrderCreatedEvent : Event
    {
        public OrderCreatedDto Order;
    }
}
