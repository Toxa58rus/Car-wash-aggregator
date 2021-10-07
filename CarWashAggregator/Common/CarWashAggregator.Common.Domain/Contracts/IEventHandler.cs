using System.Threading.Tasks;

namespace CarWashAggregator.Common.Domain.Contracts
{
    public interface IEventHandler<in TEvent>
       where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

}
