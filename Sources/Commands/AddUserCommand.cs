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
        var userData = ExtractUserData(args);
        UserBuilder builder = new UserBuilder();

        builder.SetFirstName(userData.FirstName);
        builder.SetLastName(userData.LastName);
        builder.SetPhone(userData.Phone);
        builder.SetEmail(userData.Email);

        var user = builder.Build();
        if (user.model == null)
        {
            _error = user.error;
            return;
        }

        _service.AddUser(user.model);
    }

    public override string ToString()
    {
        return _error != string.Empty
            ? $"{_error}\nUsage: add user <FirstName> <LastName> <Phone> <Email>"
            : "User added successfully.";
    }

    // ReSharper disable once MemberCanBeMadeStatic.Local
    private (string FirstName, string LastName, string Phone, string Email) ExtractUserData(string[] args)
    {
        return (args[0], args[1], args[2], args[3]);
    }
}