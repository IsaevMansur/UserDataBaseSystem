using UserDBService.Sources.Mapping;
using UserDBService.Sources.Services;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class UpdateUserCommand(IUserService userService) : UserCommandBase
{
    public override string Execute(string[] args)
    {
        if (userService.CountUsers == 0)
            return "Base is empty.";

        if (args.Length is not 5)
            return "Usage: new <FirstName> <LastName> <Phone> <Email>";

        string[] details = args[1..];

        if (!ValidationUtil.IsValidUserAddDetails(args, out var error))
            return $"{error}. Example: 1 John Johnson 9884556545 John@Johnson.com.";

        if (!long.TryParse(args[0], out var id))
            return "ID must be a number.";

        if (!userService.ContainsUser(id))
            return "User does not exist.";

        var dto = Mapper.ToUserDto(details);

        userService.UpdateUser(id, dto);
        return "User by id updated successfully.";
    }
}