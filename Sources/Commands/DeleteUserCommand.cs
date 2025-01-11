using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Interfaces.Service;

namespace UserDBService.Sources.Command;

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

        try
        {
            _userService.DeleteUser(userId);
            Console.WriteLine($"User with Id {userId} deleted successfully.");
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}