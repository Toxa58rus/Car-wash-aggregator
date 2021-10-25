using CarWashAggregator.ApiGateway.Domain.Entities;
using System.Collections.Generic;

namespace CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels
{
    public class ConstantsResult
    {
        public List<City> Cities = new List<City>();
        public List<Car> Cars = new List<Car>();
    }
}