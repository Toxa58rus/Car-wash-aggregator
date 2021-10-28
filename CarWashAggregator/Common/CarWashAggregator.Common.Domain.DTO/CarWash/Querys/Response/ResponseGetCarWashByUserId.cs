using System;
using System.Collections.Generic;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Response
{
    public class ResponseGetCarWashByUserId : Query
    {
        public List<CarWashDTO> CarWashes { get; set; }
    }
}
