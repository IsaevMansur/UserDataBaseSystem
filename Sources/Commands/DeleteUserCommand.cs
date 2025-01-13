using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class DeleteUserCommand : IUserCommand
{
    private readonly IUserService _userService;

    public DeleteUserCommand(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute(string[] args)
    {
        if (!ArgsValidationHelper.IsValidArgs(args, 1, "Usage: delete-user {userId}") ||
            !int.TryParse(args[0], out int userId))
        {
            return;
        }

        try
        {
            _userService.DeleteUser(userId);
            Console.WriteLine($"User with Id {userId} deleted successfully.");
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine($"User with Id {userId} not found.");
        }
    }
}