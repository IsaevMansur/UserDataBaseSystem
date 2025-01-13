using UserDBService.Sources.Handlers;
using UserDBService.Sources.Services;

UserCommandHandler handler = new(new DefaultUserService());

Console.WriteLine("Type a command or 'exit' to quit.");
while (true)
{
    Console.Write("> ");

    var input = Console.ReadLine();
    if (input is null or "exit") break;
    handler.ProcessCommand(input);
}