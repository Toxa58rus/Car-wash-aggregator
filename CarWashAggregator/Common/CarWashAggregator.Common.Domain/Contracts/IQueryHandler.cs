using System.Threading.Tasks;

namespace CarWashAggregator.Common.Domain.Contracts
{
    public interface IQueryHandler<in TRequest, TResponse> : IQueryHandler
       where TRequest : Query
       where TResponse : Query
    {
        Task<TResponse> Handle(TRequest request);
    }

    public interface IQueryHandler
    {

    }
}
