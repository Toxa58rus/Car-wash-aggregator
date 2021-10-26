using System;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Querys
{
    public class CarWashDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Img { get; set; }
        public string Phone { get; set; }
        public string[] CarWashCategories { get; set; }

    }
}