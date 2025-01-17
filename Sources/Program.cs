using UserDBService.Sources.Handlers;
using UserDBService.Sources.Services;

UserService service = new();
CommandHandler handler = new(service);

Console.WriteLine("Type a command or 'exit' to quit.");
while (true)
{
    Console.Write("> ");

    var input = Console.ReadLine() ?? "";
    if (input.ToLower() is "exit") break;
    handler.ProcessCommand(input);
}