using UserDBService.Sources.Mapping;
using UserDBService.Sources.Services;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class AddUserCommand : IUserCommand
{
    private readonly IUserService _userService;

    public AddUserCommand(IUserService userService) => _userService = userService;

    public string Execute(string[] args)
    {
        if (args.Length < 4)
            return "Usage: new <FirstName> <LastName> <Phone> <Email>";


        if (!ValidationUtil.IsValidUserAddDetails(args, out string error))
            return $"{error}. Example: John Johnson 9884556545 John@Johnson.com.";

        var dto = Mapper.ToUserDto(args);

        _userService.AddUser(dto);
        return "User added successfully";
    }
}