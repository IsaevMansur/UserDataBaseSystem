using UserDBService.Sources.Services;

namespace UserDBService.Sources.Commands;

public class DeleteUserCommand(IUserService service) : UserCommandBase
{
    private int _userId;

    public override string Execute(string[] args)
    {
        if (args.Length is not 1)
            return "Usage: delete <Id>";
        if (!int.TryParse(args[0], out _userId))
            return "ID must be an integer.";
        if (service.ContainsUser(_userId))
            service.DeleteUser(_userId);

        return "User deleted.";
    }
}