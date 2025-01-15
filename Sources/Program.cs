using UserDBService.Sources.Handlers;
using UserDBService.Sources.Repositories;
using UserDBService.Sources.Services;

UserRepository database = new();
DefaultService service = new(database);
CommandHandler handler = new(service);

Console.WriteLine("Type a command or 'exit' to quit.");
while (true)
{
    Console.Write("> ");

    var input = Console.ReadLine()?.Trim();
    if (input is null || input.ToLower() is "exit") break;
    handler.ProcessCommand(input);
}