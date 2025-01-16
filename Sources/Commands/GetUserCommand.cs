using ConsoleTables;
using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Commands;

public class GetUserCommand : IUserCommand
{
    private readonly IUserService _service;
    private string _error = string.Empty;
    private ConsoleTable? _table;


    public GetUserCommand(IUserService service)
    {
        _service = service;
    }

    public void Execute(string[] args)
    {
        if (_service.Count == 0)
        {
            _error = "Users not found";
            return;
        }

        if (args.Length == 0)
        {
            _error = "Usage: get <Id>";
            return;
        }

        if (!int.TryParse(args[0], out int id))
        {
            _error = "Id must be an integer";
            return;
        }

        _table = new ConsoleTable("Id", "LastName", "Email");

        if (_service.ExistsUser(id, out var user) && user is not null)
            _table.AddRow(user.Id, user.LastName, user.Email);
    }

    public override string ToString()
    {
        return _error == string.Empty && _table is not null
            ? _table.ToString()
            : _error;
    }
}