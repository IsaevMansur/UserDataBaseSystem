using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Mapping;
using UserDBService.Sources.Models;

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

    // ReSharper disable once MemberCanBeMadeStatic.Local
    private (string FirstName, string LastName, string Phone, string Email) ExtractUserData(string[] args)
    {
        return (args[0], args[1], args[2], args[3]);
    }
}