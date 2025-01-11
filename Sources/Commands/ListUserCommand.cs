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
        if (args.Length != 0)
        {
            Console.WriteLine("This command does not need arguments.");
            return;
        }

        var userList = _userService.GetAllUsers();
        Console.WriteLine("Users list:");
        Console.WriteLine("Id\t\tLastName\t\tEmail");
        foreach (IUserModel user in userList)
        {
            Console.WriteLine(user.ToString());
        }
    }
}