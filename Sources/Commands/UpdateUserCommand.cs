using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Models;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class UpdateUserCommand : IUserCommand
{
    private readonly IUserService _service;
    private (string Id, string FirstName, string LastName, string Phone, string Email) _userData;
    private (bool IsValid, string? ErrorMessage) _validationResult;

    public UpdateUserCommand(IUserService service)
    {
        _service = service;
    }

    public void Execute(string[] args)
    {
        if (!ValidationUtil.IsValidArgs(args, 5,
                "Needs arguments: <Id> <FirstName> <LastName> <Phone> <Email>"))

        {
            return;
        }

        _userData = ExtractUserData(args);
        _validationResult = ValidateUserData(_userData);

        if (!_validationResult.IsValid)
            return;

        _service.UpdateUser(long.Parse(_userData.Id),
            new UserModel(_userData.FirstName, _userData.LastName, _userData.Phone, _userData.Email));
    }

    public override string? ToString()
    {
        return _validationResult.IsValid ? $"User by Id: {_userData.Id} updated." : _validationResult.ErrorMessage;
    }

    private static (string Id, string FirstName, string LastName, string Phone, string Email) ExtractUserData(
        string[] args)
    {
        return (args[0], args[1], args[2], args[3], args[4]);
    }

    private static (bool IsValid, string? ErrorMessage) ValidateUserData(
        (string Id, string FirstName, string LastName, string Phone, string Email) userData)
    {
        if (!ValidationUtil.IsValidId(userData.Id))
            return (false, "Id field is empy or is not digits.");

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