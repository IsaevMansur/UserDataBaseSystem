using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class GetUserCommand : IUserCommand
{
    private readonly IUserService _userService;

    public GetUserCommand(IUserService userService)
    {
        _userService = userService;
    }

    public void Execute(string[] args)
    {
        if (!ArgsValidationHelper.IsValidArgs(args, 1, "Usage: get <Id>") || !args[0].All(char.IsDigit))
        {
            return;
        }

        int userId = int.Parse(args[0]);
        _userService.TryGetUserById(userId, out var user);
        if (user != null)
        {
            Console.WriteLine("Id\t\tName\t\tEmail");
            Console.WriteLine(user.ToString());
        }
        else
        {
            Console.WriteLine("Id not found");
        }
    }
}