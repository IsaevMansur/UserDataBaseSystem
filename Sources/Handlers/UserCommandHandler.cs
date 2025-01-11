using UserDBService.Sources.Commands;
using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Services;

namespace UserDBService.Sources.Handlers;

public class UserCommandHandler
{
    private static readonly UserService UserService = new();

    private readonly Dictionary<string, IUserCommand> _commands = new()
    {
        { "help", new UserCommandHelp() },
        { "new", new UserCommandAdd(UserService) },
        { "delete", new UserCommandDelete(UserService) },
        { "update", new UserCommandUpdate(UserService) },
        { "get", new UserCommandGet(UserService) },
        { "list", new UserCommandList(UserService) }
    };

    public void ProcessCommand(string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0) return;

        var commandName = parts[0].ToLower();
        var args = parts.Length > 1 ? parts[1..] : [];

        if (_commands.TryGetValue(commandName, out var command))
        {
            command.Execute(args);
        }
        else
        {
            Console.WriteLine($"Unknown command: {commandName}");
        }
    }
}