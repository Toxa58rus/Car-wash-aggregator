using System;
using System.Collections.Generic;
using System.Text;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request
{
    public class RequestCarWashByFilters : Query
    {
        public DateTime d { get; set; }
        public string CarCategory { get; set; }
        public string City { get; set; }
        public string CarWashName { get; set; }
    }
}
