using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Commands;

public class HelpCommand : IUserCommand
{
    private static readonly Dictionary<string, string> CommandsList = new()
    {
        { "help", "Shows this help message." },
        { "exit", "Exits the program." },
        { "list", "Lists all users." },
        { "new", "Adds a new user in DB. Args: <FirstName> <LastName> <Phone> <Email>" },
        { "delete", "Deletes the user from DB. Args: <Id>" },
        {
            "update",
            "Updates information the user by Id from DB. Args: <Id> <FirstName> <LastName> <Phone> <Email>"
        },
        { "get", "Gets the user from DB. Args: <Id>" }
    };

    public void Execute(string[] args)
    {
    }

    public override string ToString()
    {
        foreach (var pair in CommandsList)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }

        return "Type 'help' command for listing all commands.";
    }
}