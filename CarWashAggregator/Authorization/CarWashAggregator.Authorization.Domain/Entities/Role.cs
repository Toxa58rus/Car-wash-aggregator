namespace CarWashAggregator.Authorization.Domain.Entities
{
    public class Role : BaseEntity
    {
        public int IndexId { get; set; }
        public string Name { get; set; }
    }
}