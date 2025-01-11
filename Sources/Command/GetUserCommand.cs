using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Interfaces.Service;
using UserDBService.Sources.Services;

namespace UserDBService.Sources.Command;

public class GetUserCommand : IUserCommand
{
    private readonly IUserService _userService;

    public GetUserCommand(UserService userService)
    {
        _userService = userService;
    }

    public void Execute(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Usage: get <Id>");
            return;
        }

        int userId = int.Parse(args[0]);
        var user = _userService.GetUser(userId);
        Console.WriteLine("Id\t\tName\t\tEmail");
        Console.WriteLine(user.ToString());
    }
}