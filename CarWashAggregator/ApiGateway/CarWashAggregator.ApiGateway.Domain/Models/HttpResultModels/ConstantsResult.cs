using System.Collections.Generic;
using CarWashAggregator.ApiGateway.Domain.Models.Entities;

namespace CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels
{
    public class ConstantsResult
    {
        public List<City> Cities = new List<City>();
        public List<Car> Cars = new List<Car>();
    }
}