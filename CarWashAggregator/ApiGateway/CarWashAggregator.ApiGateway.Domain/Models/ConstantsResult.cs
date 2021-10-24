using System.Collections.Generic;
using CarWashAggregator.ApiGateway.Domain.Entities;

namespace CarWashAggregator.ApiGateway.Domain.Models
{
    public class ConstantsResult
    {
        public List<City> Cities = new List<City>();
        public List<Car> Cars = new List<Car>();
    }
}