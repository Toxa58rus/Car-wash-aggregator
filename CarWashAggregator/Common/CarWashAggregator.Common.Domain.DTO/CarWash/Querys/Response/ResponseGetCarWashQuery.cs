using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Response
{
    public class ResponseGetCarWashQuery : Query
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double AVG_Rating { get; set; }
        public string Address { get; set; }
        public string[] CarCategories { get; set; }
    }
}
