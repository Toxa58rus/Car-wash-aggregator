using CarWashAggregator.Common.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.Files.BL.Queries
{
    public class FileIdQuery : Query
    {
        public Guid Id { get; set; }
    }
}
