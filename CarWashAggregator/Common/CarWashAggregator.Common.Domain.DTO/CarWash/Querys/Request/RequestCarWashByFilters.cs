using System;
using System.Collections.Generic;
using System.Text;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request
{
    public class RequestCarWashByFilters : Query
    {
        public string CarCategory { get; set; }
        public Guid? CityId { get; set; }
        public string CarWashName { get; set; }
    }
}
