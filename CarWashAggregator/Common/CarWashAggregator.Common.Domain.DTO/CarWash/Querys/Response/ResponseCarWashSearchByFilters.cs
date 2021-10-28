using System.Collections.Generic;
using System.Text;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Response
{
   
   public class ResponseCarWashSearchByFilters :Query
    {
        public List<CarWashDTO> Washes { get; set; }
    }
}
