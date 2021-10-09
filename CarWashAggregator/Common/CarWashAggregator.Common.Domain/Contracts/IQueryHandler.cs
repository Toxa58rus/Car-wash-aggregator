using System.Threading.Tasks;

namespace CarWashAggregator.Common.Domain.Contracts
{
    public interface IQueryHandler<in TQuery>
       where TQuery : Query
    {
        Task Handle(TQuery query, string replyTo, string correlationId, ulong deliveryTag);
    }

}
