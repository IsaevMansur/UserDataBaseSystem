using ConsoleTables;
using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Commands;

public class ListUserCommand : IUserCommand
{
    private readonly IUserService _service;
    private IEnumerable<IUserModel>? _userList;

    public ListUserCommand(IUserService service)
    {
        _service = service;
    }

    public void Execute(string[] args)
    {
        _userList = _service.Count == 0 ? null : _service.GetAllUsers();
    }

    public override string ToString()
    {
        if (_userList is null) return "Base is empty";

        var table = new ConsoleTable("Id", "LastName", "Email");
        foreach (var user in _userList)
        {
            table.AddRow(user.Id, user.LastName, user.Email);
        }

        return table.ToString();
    }
}