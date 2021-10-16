using CarWashAggregator.Common.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Response
{
    public class ResponseCreateCarWashQuery : Query
    {
        public Guid Id { get; set; }
    }
}
