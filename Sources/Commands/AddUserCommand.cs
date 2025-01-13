using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Models;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class AddUserCommand : IUserCommand
{
    private readonly IUserService _userService;

    public AddUserCommand(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute(string[] args)
    {
        if (!IsValidArgs(args))
        {
            Console.WriteLine("Usage: add user <FirstName> <LastName> <Phone> <Email>");
            return;
        }

        var userData = ExtractUserData(args);

        var validationResult = ValidateUserData(userData);

        if (!validationResult.IsValid)
        {
            Console.WriteLine(validationResult.ErrorMessage);
            return;
        }

        var user = new UserModel(userData.FirstName, userData.LastName, userData.Phone, userData.Email);

        _userService.AddUser(user);
        Console.WriteLine($"User {user.FirstName} {user.LastName} added successfully.");
    }

    private static bool IsValidArgs(string[] args)
    {
        if (args.Length != 4)
        {
            Console.WriteLine("Usage: add user <FirstName> <LastName> <Phone> <Email>");
            return false;
        }

        return true;
    }

    private static (string FirstName, string LastName, string Phone, string Email) ExtractUserData(string[] args)
    {
        return (args[0], args[1], args[2], args[3]);
    }

    private static (bool IsValid, string? ErrorMessage) ValidateUserData(
        (string FirstName, string LastName, string Phone, string Email) userData)
    {
        if (!ValidationHelper.IsValidName(userData.FirstName))
            return (false, "The first name must contain at least 2 letters.");

        if (!ValidationHelper.IsValidName(userData.LastName))
            return (false, "The last name must contain at least 2 letters.");

        if (!ValidationHelper.IsValidNumber(userData.Phone))
            return (false, $"Invalid number format, example: {ValidationHelper.PhoneSample}");

        if (!ValidationHelper.IsValidEmail(userData.Email))
            return (false, $"Invalid email format, example: {ValidationHelper.EmailSample}");

        return (true, null);
    }
}