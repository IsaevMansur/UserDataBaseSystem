using ConsoleTables;
using UserDBService.Sources.Services;

namespace UserDBService.Sources.Commands;

public class ListUserCommand : IUserCommand
{
    private readonly IUserService _userService;


    public ListUserCommand(IUserService userService) => _userService = userService;

    public string Execute(string[] args)
    {
        var users = _userService.GetAllUsers();
        if (users is null)
            return "No users found";

        var table = new ConsoleTable("Id", "LastName", "Email");
        foreach (var user in users)
        {
            table.AddRow(user.Id, user.LastName, user.Email);
        }

        return table.ToString();
    }
}