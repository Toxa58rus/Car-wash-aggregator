using CarWashAggregator.Common.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request
{
    public class RequestGetCarWashesPaginatedQuery : Query
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
