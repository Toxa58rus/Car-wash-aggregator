using AutoMapper;
using CarWashAggregator.Common.Domain.Contracts;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Request;
using CarWashAggregator.Common.Domain.DTO.User.Querys.Response;
using CarWashAggregator.User.Domain.Enities;
using CarWashAggregator.User.Domain.interfaces;
using System.Threading.Tasks;

namespace CarWashAggregator.User.Business.QueryHandlers
{
    public class GetUserByUserIdQueryHandler : IQueryHandler<RequestGetUserByUserId, ResponseGetUser>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public GetUserByUserIdQueryHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<ResponseGetUser> Handle(RequestGetUserByUserId request)
        {
            UserInfo user = await _userService.GetUserByIdAsync(request.UserId);
            return _mapper.Map<ResponseGetUser>(user);
        }
    }
}
