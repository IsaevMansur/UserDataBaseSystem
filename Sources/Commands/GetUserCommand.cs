using ConsoleTables;
using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Commands;

public class GetUserCommand : IUserCommand
{
    private readonly IUserService _service;
    private readonly ConsoleTable _table = new("Id", "LastName", "Email");

    private IUserModel? _user;
    private string _error = string.Empty;

    public GetUserCommand(IUserService service)
    {
        _service = service;
    }

    public void Execute(string[] args)
    {
        if (args.Length == 0)
        {
            _error = "Usage: add user <FirstName> <LastName> <Phone> <Email>";
            return;
        }

        if (!int.TryParse(args[0], out int id))
        {
            _error = "Id must be a number";
            return;
        }


        if (_service.ExistsUser(id, out _user) && _user is not null)
            _table.AddRow(_user.Id, _user.LastName, _user.Email);
    }

    public override string ToString()
    {
        return _error == string.Empty ? _error : _table.ToString();
    }
}