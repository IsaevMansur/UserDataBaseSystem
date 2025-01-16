using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Commands;

public class DeleteUserCommand : IUserCommand
{
    private readonly IUserService _service;
    private int _userId;
    private string _error = string.Empty;

    public DeleteUserCommand(IUserService service)
    {
        _service = service;
    }


    public void Execute(string[] args)
    {
        if (!int.TryParse(args[0], out _userId))
        {
            _error = "ID must be an integer";
            return;
        }

        if (_service.ExistsUser(_userId, out _))
            _service.DeleteUser(_userId);

        _error = $"User with Id {_userId} not found.";
    }

    public override string ToString()
    {
        return _error == string.Empty
            ? $"User with Id {_userId} deleted successfully."
            : _error;
    }
}