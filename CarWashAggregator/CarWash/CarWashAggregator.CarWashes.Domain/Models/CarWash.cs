using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarWashAggregator.CarWashes.Domain.Models
{
    public class CarWash
    {
        [Key]
        public Guid Id { get; set; }
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
