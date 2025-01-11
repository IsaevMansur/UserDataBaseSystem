using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Interfaces.Service;
using UserDBService.Sources.Models;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class UserCommandAdd : IUserCommand
{
    private readonly IUserService _userService;

    public UserCommandAdd(IUserService userService)
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

        if (!ValidationHelperUtil.IsValidName(args[0]))
        {
            Console.WriteLine("The first name must contain at least 2 letters.");
            return;
        }

        if (!ValidationHelperUtil.IsValidName(args[1]))
        {
            Console.WriteLine("The last name must contain at least 2 letters.");
            return;
        }

        if (!ValidationHelperUtil.IsValidEmail(args[3]))
        {
            Console.WriteLine($"Invalid email format, example: {ValidationHelperUtil.EmailSample}");
            return;
        }

        if (!ValidationHelperUtil.IsValidNumber(args[2]))
        {
            Console.WriteLine($"Invalid number format, example: {ValidationHelperUtil.PhoneNumberSample}");
            return;
        }

        var user = new UserModel(args[0], args[1], args[2], args[3]);

        _userService.AddUser(user);
        Console.WriteLine($"User {user.FirstName} {user.LastName} added successfully.");
    }
}