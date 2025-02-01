using UserDBService.Sources.Handlers;
using UserDBService.Sources.Interfaces.Repositories;
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

    if (input.ToLower() is "exit" && input.ToLower() is "") break;
    handler.ProcessCommand(input);
}