using UserDBService.Sources.Interfaces;
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
            _error = "Usage: add user <FirstName> <LastName> <Phone> <Email>";
            return;
        }

        var userData = ExtractUserData(args);
        var builder = new UserBuilder()
            .SetFirstName(userData.FirstName)
            .SetLastName(userData.LastName)
            .SetPhone(userData.Phone)
            .SetEmail(userData.Email);

        var user = builder.Build();

        if (user.Model is null)
        {
            _error = user.Error;
            return;
        }

        _service.AddUser(user.Model);
    }

    public override string ToString()
    {
        return _error == string.Empty
            ? "User added successfully."
            : _error;
    }

    // ReSharper disable once MemberCanBeMadeStatic.Local
    private (string FirstName, string LastName, string Phone, string Email) ExtractUserData(string[] args)
    {
        return (args[0], args[1], args[2], args[3]);
    }
}