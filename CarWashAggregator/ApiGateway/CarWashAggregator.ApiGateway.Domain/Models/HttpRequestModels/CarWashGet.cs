using Microsoft.AspNetCore.Mvc;

namespace CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels
{
    public class CarWashGet
    {
        [FromRoute]
        public string Id { get; set; }
        [FromQuery]
        public string Date { get; set; }
        [FromQuery]
        public string Time { get; set; }

    }
}
