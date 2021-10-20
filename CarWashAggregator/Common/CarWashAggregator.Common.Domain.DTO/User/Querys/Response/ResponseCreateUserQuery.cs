using CarWashAggregator.Common.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.Common.Domain.DTO.User.Querys.Response
{
    public class ResponseCreateUserQuery : Query
    {
        public Guid Id { get; set; }
    }
}
