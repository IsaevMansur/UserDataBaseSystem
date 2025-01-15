using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Models;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class UpdateUserCommand : IUserCommand
{
    private readonly IUserService _service;
    private string _error = string.Empty;


    public UpdateUserCommand(IUserService service)
    {
        _service = service;
    }

    public void Execute(string[] args)
    {
        if (!ValidationUtil.IsValidId(args[0]))
            return;

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

        _service.UpdateUser(long.Parse(userData.Id), user.model);
    }

    public override string ToString()
    {
        return _error != string.Empty
            ? $"{_error}\nUsage: update user <Id> <FirstName> <LastName> <Phone> <Email>"
            : "User by id updated successfully.";
    }

    // ReSharper disable once MemberCanBeMadeStatic.Local
    private (string Id, string FirstName, string LastName, string Phone, string Email) ExtractUserData(
        string[] args)
    {
        return (args[0], args[1], args[2], args[3], args[4]);
    }
}