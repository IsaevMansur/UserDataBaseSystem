namespace UserDBService.Sources.Utils;

public struct CommandHelpList
{
    public static readonly Dictionary<string, string> CommandsList = new()
    {
        { "help", "Shows this help message." },
        { "exit", "Exits the program." },
        { "list", "Lists all users." },
        { "new", "Adds a new user in DB. Args: <FirstName> <LastName> <Phone> <Email>" },
        { "delete", "Deletes a user from DB. Args: <Id>" },
        {
            "update",
            "Updates information the user of Id from DB. Args: <Id> <FirstName> <LastName> <Phone> <Email>"
        },
        { "get", "Gets a user from DB. Args: <Id>" }
    };
}