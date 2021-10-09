using System.Threading.Tasks;

namespace CarWashAggregator.Common.Domain.Contracts
{
    public interface IQueryHandler<TQuery>
       where TQuery : Query
    {
        Task<TQuery> Handle(TQuery query);
    }

}
