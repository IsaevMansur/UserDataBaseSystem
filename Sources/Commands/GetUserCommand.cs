using ConsoleTables;
using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class GetUserCommand : IUserCommand
{
    private readonly IUserService _service;
    private IUserModel? _user;
    private readonly ConsoleTable _table = new("Id", "LastName", "Email");

    public GetUserCommand(IUserService service)
    {
        _service = service;
    }

    public void Execute(string[] args)
    {
        if (!ValidationUtil.IsValidArgs(args, 1, "Usage: get <Id>") ||
            !int.TryParse(args[0], out int id))
        {
            return;
        }

        _service.UserExistsById(id, out _user);
        if (_user != null)
        {
            _table.AddRow(_user.Id, _user.LastName, _user.Email);
        }
    }

    public override string ToString()
    {
        return _user is not null ? _table.ToString() : "Id not found";
    }
}