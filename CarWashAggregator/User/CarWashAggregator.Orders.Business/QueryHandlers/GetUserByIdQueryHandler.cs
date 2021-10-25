namespace CarWashAggregator.User.Business.QueryHandlers
{
    //public class GetUserByIdQueryHandler : IQueryHandler<RequestGetUserByIdQuery, ResponseGetUserByIdQuery>
    //{
    //    private readonly IUserService _userService;

    //    public GetUserByIdQueryHandler(IUserService userService)
    //    {
    //        _userService = userService;
    //    }

    //    public async Task<ResponseGetUserByIdQuery> Handle(RequestGetUserByIdQuery request)
    //    {
    //        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UserInfo, ResponseGetUserByIdQuery>()));

    //        UserInfo user = await _userService.GetUserByIdAsync(request.Id);
    //        return mapper.Map<ResponseGetUserByIdQuery>(user);
    //    }
    //}
}
