using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Files.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarWashAggregator.Files.BL.Queries
{
    public class FileQuery : Query
    {
        public FileModel File { get; set; }
    }
}
