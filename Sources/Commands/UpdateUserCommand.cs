using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Models;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class UpdateUserCommand : IUserCommand
{
    private readonly IUserService _userService;

    public UpdateUserCommand(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute(string[] args)
    {
        if (args.Length != 5 && args[0].All(char.IsDigit))
        {
            Console.WriteLine("Needs arguments: <Id> <FirstName> <LastName> <Phone> <Email>");
            return;
        }

        var userData = ExtractUserData(args);
        var validationResult = ValidateUserData(userData);

        if (!validationResult.IsValid)
            Console.WriteLine(validationResult.ErrorMessage);

        _userService.UpdateUser(long.Parse(userData.Id),
            new UserModel(userData.FirstName, userData.LastName, userData.Phone, userData.Email));
        Console.WriteLine($"User by Id: {userData.Id} updated.");
    }

    private static (string Id, string FirstName, string LastName, string Phone, string Email) ExtractUserData(
        string[] args)
    {
        return (args[0], args[1], args[2], args[3], args[4]);
    }

    private static (bool IsValid, string? ErrorMessage) ValidateUserData(
        (string Id, string FirstName, string LastName, string Phone, string Email) userData)
    {
        if (!ValidationHelper.IsValidId(userData.Id))
            return (false, "Id field is empy or is not digits.");

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