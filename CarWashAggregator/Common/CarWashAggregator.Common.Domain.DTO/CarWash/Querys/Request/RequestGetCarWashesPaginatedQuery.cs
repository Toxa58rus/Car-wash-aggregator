using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.CarWash.Querys.Request
{
    public class RequestGetCarWashesPaginatedQuery : Query
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
