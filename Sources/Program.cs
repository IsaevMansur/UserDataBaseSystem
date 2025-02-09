using UserDBService.Sources.Handlers;
using UserDBService.Sources.Interfaces.Repositories;
using UserDBService.Sources.Models;
using UserDBService.Sources.Repositories;
using UserDBService.Sources.Services;

IUserRepository db = new MemoryUserRepository();
UserService service = new(db);
CommandHandler handler = new(service);

Console.WriteLine("Type a command or 'exit' to quit.");
while (true)
{
    Console.Write("> ");

    string input = Console.ReadLine() ?? "";

    if (input.ToLower() is "exit")
        break;
    if (input.ToLower() is "")
        continue;

    handler.ProcessCommand(input);
}
