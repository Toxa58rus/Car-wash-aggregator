using System.Threading.Tasks;

namespace CarWashAggregator.Common.Domain.Contracts
{
    public interface IReturnedQueryHandler<in TQuery>
       where TQuery : Query
    {
        Task Handle(TQuery query);
    }

}
