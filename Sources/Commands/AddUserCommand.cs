using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Models;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class AddUserCommand : IUserCommand
{
    private readonly IUserService _service;
    private readonly UserModel _user = new();
    (bool IsValid, string? ErrorMessage) validationResult;

    public AddUserCommand(IUserService service)
    {
        _service = service;
    }

    public void Execute(string[] args)
    {
        if (!ValidationUtil.IsValidArgs(args, 4,
                "Usage: add user <FirstName> <LastName> <Phone> <Email>"))
            return;

        var userData = ExtractUserData(args);

        validationResult = ValidateUserData(userData);

        if (!validationResult.IsValid)
            return;

        _user.FirstName = userData.FirstName;
        _user.LastName = userData.LastName;
        _user.Phone = userData.Phone;
        _user.Email = userData.Email;

        _service.AddUser(_user);
    }

    public override string ToString()
    {
        return validationResult.IsValid ? "User added successfully" : $"{validationResult.ErrorMessage}";
    }

    private static (string FirstName, string LastName, string Phone, string Email) ExtractUserData(string[] args)
    {
        return (args[0], args[1], args[2], args[3]);
    }

    private static (bool IsValid, string? ErrorMessage) ValidateUserData(
        (string FirstName, string LastName, string Phone, string Email) userData)
    {
        if (!ValidationUtil.IsValidName(userData.FirstName))
            return (false, "The first name must contain at least 2 letters.");

        if (!ValidationUtil.IsValidName(userData.LastName))
            return (false, "The last name must contain at least 2 letters.");

        if (!ValidationUtil.IsValidNumber(userData.Phone))
            return (false, $"Invalid number format, example: {ValidationUtil.PhoneSample}");

        if (!ValidationUtil.IsValidEmail(userData.Email))
            return (false, $"Invalid email format, example: {ValidationUtil.EmailSample}");

        return (true, null);
    }
}