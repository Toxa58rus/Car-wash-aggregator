using CarWashAggregator.Common.Domain.Contracts;

namespace CarWashAggregator.Common.Domain.DTO.User.Querys.Response
{
    public class ResponseRoleIdByUserIdQuery : Query
    {
        public int Role { get; set; }
    }
}
