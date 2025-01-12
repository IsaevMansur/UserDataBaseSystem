using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class HelpUserCommand : IUserCommand
{
    public void Execute(string[] args)
    {
        foreach (var pair in CommandHelpList.CommandsList)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
    }
}