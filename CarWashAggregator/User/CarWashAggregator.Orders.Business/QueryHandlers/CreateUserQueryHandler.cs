namespace CarWashAggregator.User.Business.QueryHandlers
{
    //public class CreateUserQueryHandler : IQueryHandler<RequestRoleIdByUserIdQuery, ResponseCreateUserQuery>
    //{
    //    private readonly IUserService _userService;

    //    public CreateUserQueryHandler(IUserService userService)
    //    {
    //        _userService = userService;
    //    }

    //    public async Task<ResponseCreateUserQuery> Handle(RequestRoleIdByUserIdQuery request)
    //    {
    //        var mapper = new Mapper(
    //            new MapperConfiguration(cfg => cfg.CreateMap<RequestRoleIdByUserIdQuery, UserInfo>()
    //                .ForMember("Role", opt => opt.Ignore())
    //        ));
    //        UserInfo user = mapper.Map<UserInfo>(request);

    //        Guid id = await _userService.CreateUserAsync(user);

    //        return new ResponseCreateUserQuery() { Id = id };
    //    }
    //}
}
