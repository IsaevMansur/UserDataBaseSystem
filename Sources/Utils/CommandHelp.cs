namespace UserDBService.Sources.Utils;

public struct CommandHelp
{
    public static readonly Dictionary<string, string> CommandsList = new()
    {
        { "help", "Shows this help message." },
        { "exit", "Exits the program. Not Args" },
        { "new", "Adds a new user in DB. Args: <FirstName> <LastName> <PhoneNumber> <Email>" },
        { "delete", "Deletes a user from DB. Args: <Id>" },
        {
            "update",
            "Updates information the user of Id from DB. Args: <Id> <FirstName> <LastName> <PhoneNumber> <Email>"
        },
        { "get", "Gets a user from DB. Args: <Id>" },
        { "list", "Lists all users. Not Args" }
    };
}