using ConsoleTables;
using UserDBService.Sources.Services;

namespace UserDBService.Sources.Commands;

public class ListUserCommand(IUserService userService) : UserCommandBase
{
    public override string Execute(string[] args)
    {
        var users = userService.GetAllUsers();
        if (users is null)
            return "No users found";

        var table = new ConsoleTable("Id", "LastName", "Email");
        foreach (var user in users) table.AddRow(user.Id, user.LastName, user.Email);

        return table.ToString();
    }
}