using UserDBService.Sources.Handlers;

UserCommandHandler handler = new UserCommandHandler();

Console.WriteLine("Type a command or 'exit' to quit.");
while (true)
{
    Console.Write("> ");
    var input = Console.ReadLine();
    if (input == null) break;
    var commands = input.Split(' ');
    if (commands[0] == "exit") break;

    handler.ProcessCommand(input);
}