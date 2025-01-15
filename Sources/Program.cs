using UserDBService.Sources.Handlers;
using UserDBService.Sources.Repository;
using UserDBService.Sources.Services;

UserRepository database = new();
DefaultService service = new(database);
CommandHandler handler = new(service);

Console.WriteLine("Type a command or 'exit' to quit.");
while (true)
{
    Console.Write("> ");

    var input = Console.ReadLine();
    if (input is null or "exit") break;
    handler.ProcessCommand(input);
}