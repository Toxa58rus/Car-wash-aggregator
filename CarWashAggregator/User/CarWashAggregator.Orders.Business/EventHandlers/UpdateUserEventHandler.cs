namespace CarWashAggregator.User.Business.EventHandlers
{
    //public class UpdateUserEventHandler : IEventHandler<UpdateUserEvent>
    //{
    //    private readonly IUserService _userService;

    //    public UpdateUserEventHandler(IUserService userService)
    //    {
    //        _userService = userService;
    //    }

    //    public async Task Handle(UpdateUserEvent @event)
    //    {
    //        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<UpdateUserEvent, UserInfo>()));
    //        UserInfo user = await _userService.GetUserByIdAsync(@event.Id);
    //        user = mapper.Map(@event, user);
    //        await _userService.UpdateUserAsync(user);
    //    }
    //}
}
