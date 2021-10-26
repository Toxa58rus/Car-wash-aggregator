namespace CarWashAggregator.ApiGateway.Domain.Models.HttpRequestModels
{
    public class CarWashSearch
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string CarCategory { get; set; }
        public string City { get; set; }
        public string CarWashName { get; set; }
    }
}
