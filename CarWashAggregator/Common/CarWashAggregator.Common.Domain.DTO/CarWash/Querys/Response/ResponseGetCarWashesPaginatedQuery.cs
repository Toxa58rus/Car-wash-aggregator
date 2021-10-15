using CarWashAggregator.Common.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Response
{
    public class ResponseGetCarWashesPaginatedQuery : Query
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public IEnumerable<CarWashes.Domain.Models.CarWash> Data { get; set; }
    }
}
