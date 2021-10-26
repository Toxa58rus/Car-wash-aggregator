namespace CarWashAggregator.ApiGateway.Domain.Models.HttpResultModels.Base
{
    public class CommentModel
    {
        public CommentModelUser User { get; set; }
        public string Date { get; set; }
        public string Rating { get; set; }
        public string Comment { get; set; }
    }

    public class CommentModelUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
