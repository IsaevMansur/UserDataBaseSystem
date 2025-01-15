using UserDBService.Sources.Commands;
using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Handlers;

public class CommandHandler(IUserService service)
{
    private readonly Dictionary<string, IUserCommand> _commands = new()
    {
        { "help", new HelpCommand() },
        { "new", new AddUserCommand(service) },
        { "delete", new DeleteUserCommand(service) },
        { "update", new UpdateUserCommand(service) },
        { "get", new GetUserCommand(service) },
        { "list", new ListUserCommand(service) }
    };

    public void ProcessCommand(string input)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0) return;

        string commandName = parts[0].ToLower();
        string[] args = parts.Length > 1 ? parts[1..] : [];

        if (_commands.TryGetValue(commandName, out var command))
        {
            command.Execute(args);
            Console.WriteLine(command.ToString());
        }
        else
        {
            Console.WriteLine($"Unknown command: {commandName}");
        }
    }
}