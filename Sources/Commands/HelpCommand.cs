﻿namespace UserDBService.Sources.Commands;

public class HelpCommand : IUserCommand
{
    private static readonly Dictionary<string, string> CommandsList = new()
    {
        { "help", "Shows this help message." },
        { "exit", "Exits the program." },
        { "list", "Lists all users." },
        { "new", "Adds a new user in DB. Usage: new <FirstName> <LastName> <Phone> <Email>" },
        { "delete", "Deletes the user from DB. Usage: delete <Id>" },
        {
            "update",
            "Updates information the user by Id from DB. Usage: update <Id> <FirstName> <LastName> <Phone> <Email>"
        },
        { "get", "Gets the user from DB. Usage: get <Id>" }
    };

    public string Execute(string[] args)
    {
        foreach (var pair in CommandsList)
            Console.WriteLine(pair.Key + ": " + pair.Value);

        return "Type 'help' command for listing all commands.";
    }
}