using System.Collections.Generic;
using System.Threading.Tasks;
using CarWashAggregator.ApiGateway.Business.Interfaces;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.ApiGateway.Business.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IEventBus _bus;

        public AuthorizationService(IEventBus bus)
        {
            _bus = bus;
        }

        
    }
}
