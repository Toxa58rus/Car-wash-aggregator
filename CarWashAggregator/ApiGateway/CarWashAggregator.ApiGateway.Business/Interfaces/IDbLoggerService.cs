using System.Threading.Tasks;

namespace CarWashAggregator.ApiGateway.Business.Interfaces
{
    public interface IDbLoggerService
    {
        Task LogMessageAsync(string message);
    }
}