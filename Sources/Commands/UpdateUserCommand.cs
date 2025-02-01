using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Mapping;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class UpdateUserCommand : IUserCommand
{
    private readonly IUserService _userService;

    public UpdateUserCommand(IUserService userService) => _userService = userService;

    public string Execute(string[] args)
    {
        string[] details = args[1..];
        if (_userService.CountUsers == 0)
            return "Base is empty.";

        if (args.Length < 5 && !ValidationUtil.IsValidUserAddDetails(details))
            return "Usage: update <Id> <Firstname> <Lastname> <Phone> <Email>.";

        if (!long.TryParse(args[0], out long id))
            return "ID must be a number.";

        if (!_userService.ContainsUser(id))
            return "User does not exist.";

        var dto = Mapper.ToUserDto(details);

        _userService.UpdateUser(id, dto);
        return "User by id updated successfully.";
    }
}