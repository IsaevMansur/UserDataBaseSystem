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
        var builder = new UserBuilder()
            .SetFirstName(userData.FirstName)
            .SetLastName(userData.LastName)
            .SetPhone(userData.Phone)
            .SetEmail(userData.Email);

        var user = builder.Build();
        if (user.Model == null)
        {
            _error = user.Error + '\n' + "Usage: update <Id> <FirstName> <LastName> <Phone> <Email>";
            return;
        }

        _service.UpdateUser(id: long.Parse(userData.Id), vice: user.Model);
    }

    public override string ToString()
    {
        return _error == string.Empty ? "User by id updated successfully." : _error;
    }

    // ReSharper disable once MemberCanBeMadeStatic.Local
    private (string Id, string FirstName, string LastName, string Phone, string Email) ExtractUserData(
        string[] args)
    {
        return (args[0], args[1], args[2], args[3], args[4]);
    }
}