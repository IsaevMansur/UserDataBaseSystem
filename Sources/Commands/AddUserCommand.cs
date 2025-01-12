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
        if (args.Length < 4)
        {
            Console.WriteLine("Usage: add user <FirstName> <LastName> <Phone> <Email>");
            return;
        }

        string firstName = args[0];
        string lastName = args[1];
        string phone = args[2];
        string email = args[3];

        if (!ValidationHelper.IsValidName(firstName))
        {
            Console.WriteLine("The first name must contain at least 2 letters.");
            return;
        }

        if (!ValidationHelper.IsValidName(lastName))
        {
            Console.WriteLine("The last name must contain at least 2 letters.");
            return;
        }

        if (!ValidationHelper.IsValidEmail(phone))
        {
            Console.WriteLine($"Invalid email format, example: {ValidationHelper.EmailSample}");
            return;
        }

        if (!ValidationHelper.IsValidNumber(email))
        {
            Console.WriteLine($"Invalid number format, example: {ValidationHelper.PhoneSample}");
            return;
        }

        var user = new UserModel(firstName, lastName, phone, email);

        _userService.AddUser(user);
        Console.WriteLine($"User {user.FirstName} {user.LastName} added successfully.");
    }
}