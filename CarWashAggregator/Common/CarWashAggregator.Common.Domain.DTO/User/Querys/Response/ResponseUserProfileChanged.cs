using System;
using System.Collections.Generic;
using System.Text;
using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.User.Querys.Response
{
   public class ResponseUserProfileChanged:Query
    {
        public bool Success { get; set; }
    }
}
