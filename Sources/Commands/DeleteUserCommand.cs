using UserDBService.Sources.Interfaces;

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
        if (!IsValidArgs(args, out int userId))
        {
            Console.WriteLine($"Usage: delete-user {userId}");
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

    private static bool IsValidArgs(string[] args, out int userId)
    {
        if (args.Length != 1 || !int.TryParse(args[0], out userId))
        {
            userId = default;
            return false;
        }

        return true;
    }
}