using ConsoleTables;
using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Commands;

public class ListUserCommand : IUserCommand
{
    private readonly IUserService _service;


    public ListUserCommand(IUserService service) => _service = service;

    public string Execute(string[] args)
    {
        var users = _service.GetAllUsers();
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