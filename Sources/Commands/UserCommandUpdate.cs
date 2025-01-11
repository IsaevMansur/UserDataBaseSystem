using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Interfaces.Service;
using UserDBService.Sources.Models;

namespace UserDBService.Sources.Commands;

public class UserCommandUpdate : IUserCommand
{
    private readonly IUserService _userService;

    public UserCommandUpdate(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute(string[] args)
    {
        if (args.Length < 5)
        {
            Console.WriteLine("Needs arguments: <Id> <FirstName> <LastName> <PhoneNumber> <Email>");
            return;
        }

        var userId = int.Parse(args[0]);
        var updatedUser = new UserModel(args[1], args[2], args[3], args[4]);

        _userService.UpdateUser(userId, updatedUser);
        Console.WriteLine($"User by Id: {userId} updated.");
    }
}