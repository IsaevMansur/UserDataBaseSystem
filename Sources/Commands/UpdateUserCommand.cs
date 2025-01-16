using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Mapping;
using UserDBService.Sources.Models;

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
        if (_service.Count == 0)
        {
            _error = "Base is empty.";
            return;
        }

        if (args.Length == 0)
        {
            _error = "Usage: update <Id> <Firstname> <Lastname> <Phone> <Email>.";
            return;
        }

        if (!long.TryParse(args[0], out long id))
        {
            _error = "Id must be an integer.";
            return;
        }

        if (!_service.TryGetUser(id, out _))
        {
            _error = "Id not found.";
            return;
        }

        var userData = ExtractUserData(args);

        var dto = ModelToDto.Map(new UserModel(userData.FirstName,
            userData.LastName,
            userData.Phone,
            userData.Email));

        _service.UpdateUser(id, dto);
    }

    public override string ToString()
    {
        string result = _error == string.Empty ? "User by id updated successfully." : _error;
        _error = string.Empty;
        return result;
    }

    // ReSharper disable once MemberCanBeMadeStatic.Local
    private (string Id, string FirstName, string LastName, string Phone, string Email) ExtractUserData(
        string[] args)
    {
        return (args[0], args[1], args[2], args[3], args[4]);
    }
}