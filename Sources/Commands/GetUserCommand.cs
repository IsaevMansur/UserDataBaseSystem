using UserDBService.Sources.Mapping;
using UserDBService.Sources.Services;

namespace UserDBService.Sources.Commands;

public class GetUserCommand : IUserCommand
{
    private readonly IUserService _userService;


    public GetUserCommand(IUserService userService) => _userService = userService;

    public string Execute(string[] args)
    {
        if (_userService.CountUsers == 0)
            return "Base is empty.";

        if (args.Length < 1)
            return "Usage: get <Id>.";

        if (!long.TryParse(args[0], out long id))
            return "Id must be an integer.";

        if (!_userService.ContainsUser(id))
            return $"User with id {id} not found.";

        var dto = _userService.GetUser(id);
        var model = Mapper.ToUserModel(dto);
        model.Id = id;
        return model.ToString();
    }
}