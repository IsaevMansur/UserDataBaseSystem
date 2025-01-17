using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Mapping;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class AddUserCommand : IUserCommand
{
    private readonly IUserService _service;
    private string _error = string.Empty;

    public AddUserCommand(IUserService service)
    {
        _service = service;
    }

    public void Execute(string[] args)
    {
        if (args.Length < 4)
        {
            _error = "Usage: new <FirstName> <LastName> <Phone> <Email>";
            return;
        }

        if (!ValidationUtil.IsValidName(args[0]))
        {
            _error = "First name must be between 2 and 50 characters.";
            return;
        }

        if (!ValidationUtil.IsValidName(args[1]))
        {
            _error = "Last name must be between 2 and 50 characters.";
            return;
        }

        if (!ValidationUtil.IsValidPhone(args[2]))
        {
            _error = $"Invalid phone number format. Valid format {ValidationUtil.PhoneSample}";
            return;
        }

        if (!ValidationUtil.IsValidEmail(args[3]))
        {
            _error = $"Invalid email format. Valid format {ValidationUtil.EmailSample}";
            return;
        }

        var dto = ModelToDto.Map(args);

        _service.AddUser(dto);
    }

    public override string ToString()
    {
        string result = _error == string.Empty
            ? "User added successfully."
            : _error;
        _error = string.Empty;
        return result;
    }
}