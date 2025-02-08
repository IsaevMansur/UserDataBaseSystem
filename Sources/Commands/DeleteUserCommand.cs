using UserDBService.Sources.Services;

namespace UserDBService.Sources.Commands;

public class DeleteUserCommand : UserCommandBase
{
    private readonly IUserService _service;
    private int _userId;

    public DeleteUserCommand(IUserService service) => _service = service;

    public override string Execute(string[] args)
    {
        if (args.Length is not 1)
            return "Usage: delete <Id>";
        if (!int.TryParse(args[0], out _userId))
            return "ID must be an integer.";
        if (_service.ContainsUser(_userId))
            _service.DeleteUser(_userId);

        return "User deleted.";
    }
}
