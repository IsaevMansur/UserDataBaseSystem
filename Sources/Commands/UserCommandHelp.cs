using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class UserCommandHelp : IUserCommand
{
    public void Execute(string[] args)
    {
        if (args.Length > 1)
        {
            Console.WriteLine("This command does not need arguments.");
            return;
        }

        foreach (var pair in CommandHelpListUtil.CommandsList)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
    }
}