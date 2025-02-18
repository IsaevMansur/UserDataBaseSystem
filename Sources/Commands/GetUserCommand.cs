using UserDBService.Sources.Mapping;
using UserDBService.Sources.Services;

namespace UserDBService.Sources.Commands;

public class GetUserCommand(IUserService userService) : UserCommandBase
{
    public override string Execute(string[] args)
    {
        if (userService.CountUsers == 0)
            return "Base is empty.";

        if (args.Length is not 1)
            return "Usage: get <Id>.";

        if (!long.TryParse(args[0], out var id))
            return "Id must be an integer.";

        if (!userService.ContainsUser(id))
            return $"User with id {id} not found.";

        var dto = userService.GetUser(id);
        var model = Mapper.ToUserModel(dto);
        model.Id = id;
        return model.ToString();
    }
}