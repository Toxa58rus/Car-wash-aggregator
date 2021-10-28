using System;
using System.Collections.Generic;
using System.Text;

namespace CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels
{
   public class CarWashAdd
    {
        public string PartnerId { get; set; }
        public string Name { get; set; }
        public string CityId { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string[] CarCategories { get; set; }
        public string Phone { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
    }
}
