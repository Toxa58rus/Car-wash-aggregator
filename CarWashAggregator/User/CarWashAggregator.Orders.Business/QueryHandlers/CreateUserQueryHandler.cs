namespace CarWashAggregator.User.Business.QueryHandlers
{
    //public class CreateUserQueryHandler : IQueryHandler<RequestRoleIdByAuthId, ResponseCreateUserQuery>
    //{
    //    private readonly IUserService _userService;

    //    public CreateUserQueryHandler(IUserService userService)
    //    {
    //        _userService = userService;
    //    }

    //    public async Task<ResponseCreateUserQuery> Handle(RequestRoleIdByAuthId request)
    //    {
    //        var mapper = new Mapper(
    //            new MapperConfiguration(cfg => cfg.CreateMap<RequestRoleIdByAuthId, UserInfo>()
    //                .ForMember("Role", opt => opt.Ignore())
    //        ));
    //        UserInfo user = mapper.Map<UserInfo>(request);

    //        Guid id = await _userService.CreateUserAsync(user);

    //        return new ResponseCreateUserQuery() { Id = id };
    //    }
    //}
}
