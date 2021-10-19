using CarWashAggregator.Common.Domain.Contracts;
using System;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request
{
    public class RequestCreateCarWashQuery : Query
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string[] CarCategories { get; set; }
    }
}
