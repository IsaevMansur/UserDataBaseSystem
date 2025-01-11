using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Interfaces.Service;

namespace UserDBService.Sources.Commands;

public class UserCommandDelete : IUserCommand
{
    private readonly IUserService _userService;

    public UserCommandDelete(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute(string[] args)
    {
        if (args.Length > 1 || !int.TryParse(args[0], out int userId))
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