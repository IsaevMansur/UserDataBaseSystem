using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Services;

namespace UserDBService.Sources.Commands;

public class GetUserCommand : IUserCommand
{
    private readonly IUserService _userService;

    public GetUserCommand(UserService userService)
    {
        _userService = userService;
    }

    public void Execute(string[] args)
    {
        if (!IsValidArgs(args))
        {
            Console.WriteLine("Usage: get <Id>");
            return;
        }

        int userId = int.Parse(args[0]);
        _userService.TryGetUserById(userId, out var user);
        if (user != null)
        {
            Console.WriteLine("Id\t\tName\t\tEmail");
            Console.WriteLine(user.ToString());
        }
        else
        {
            Console.WriteLine("Id not found");
        }
    }

    private static bool IsValidArgs(string[] args)
    {
        if (args.Length != 1 && !args[0].All(char.IsDigit))
        {
            Console.WriteLine("Usage: get <Id>");
            return false;
        }

        return true;
    }
}