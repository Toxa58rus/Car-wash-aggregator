using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.Events;

namespace CarWashAggregator.Orders.Business.Events
{
    public class OrderCreatedEvent : Event
    {
        public OrderCreatedDto order;
    }
}
