using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Interfaces.Service;
using UserDBService.Sources.Models;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Command;

public class AddUserCommand : IUserCommand
{
    private readonly IUserService _userService;

    public AddUserCommand(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute(string[] args)
    {
        if (args.Length < 4)
        {
            Console.WriteLine("Usage: add user <FirstName> <LastName> <PhoneNumber> <Email>");
            return;
        }

        if (!ValidationHelper.IsValidNumber(args[2]) && !ValidationHelper.IsValidEmail(args[3]))
        {
            Console.WriteLine("Invalid email format or email address");
            return;
        }

        var user = new UserModel(args[0], args[1], args[2], args[3]);

        _userService.AddUser(user);
        Console.WriteLine($"User {user.FirstName} {user.LastName} added successfully.");
    }
}