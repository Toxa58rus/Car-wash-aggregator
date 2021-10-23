using System.Threading.Tasks;

namespace CarWashAggregator.Common.Domain.Contracts
{
    public interface IQueryHandler<in TRequest, TResponse>
       where TRequest : Query
       where TResponse : Query
    {
        Task<TResponse> Handle(TRequest request);
    }
}
