using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Response
{
    public class ResponseGetCarWashById : Query
    {
       public CarWashDTO Wash { get; set; }
    }
}
