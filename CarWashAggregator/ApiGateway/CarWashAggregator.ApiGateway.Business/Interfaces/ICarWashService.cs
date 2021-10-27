using System.Threading.Tasks;
using CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels;
using CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels;

namespace CarWashAggregator.ApiGateway.Business.Interfaces
{
    public interface ICarWashService
    {
        Task<SearchWashesResult> SearchAsync(CarWashSearch query);
    }
}