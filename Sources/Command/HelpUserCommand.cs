using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Command;

public class HelpUserCommand : IUserCommand
{
    public void Execute(string[] args)
    {
        if (args.Length > 1)
        {
            Console.WriteLine("This command does not need arguments.");
            return;
        }

        foreach (var pair in CommandHelp.CommandsList)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
    }
}