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
        if (args.Length < 1 || !int.TryParse(args[0], out int userId))
        {
            Console.WriteLine("Usage: delete user <UserId>");
            return;
        }

        if (_userService.TryGetUserById(userId, out _))
        {
            _userService.DeleteUser(userId);
            Console.WriteLine($"User with Id {userId} deleted successfully.");
        }
        else
        {
            Console.WriteLine($"User with Id {userId} not found.");
        }
    }
}