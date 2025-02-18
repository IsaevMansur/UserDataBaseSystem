using UserDBService.Sources.Mapping;
using UserDBService.Sources.Services;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class AddUserCommand(IUserService userService) : UserCommandBase
{
    public override string Execute(string[] args)
    {
        if (args.Length is not 4)
            return "Usage: new <FirstName> <LastName> <Phone> <Email>";

        if (!ValidationUtil.IsValidUserAddDetails(args, out var error))
            return $"{error}. Example: John Johnson 9884556545 John@Johnson.com.";

        var dto = Mapper.ToUserDto(args);

        userService.AddUser(dto);
        return "User added successfully";
    }
}