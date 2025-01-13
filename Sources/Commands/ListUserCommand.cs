using ConsoleTables;
using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Commands;

public class ListUserCommand : IUserCommand
{
    private readonly IUserService _userService;

    public ListUserCommand(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute(string[] args)
    {
        var userList = _userService.GetAllUsers();

        var table = new ConsoleTable("Id", "LastName", "Email");

        foreach (var user in userList)
        {
            table.AddRow(user.Id, user.LastName, user.Email);
        }

        table.Write();
    }
}