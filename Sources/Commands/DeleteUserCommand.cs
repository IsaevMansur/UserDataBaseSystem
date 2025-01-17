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
        if (args.Length < 1)
        {
            _error = "Usage: delete <Id>";
            return;
        }

        if (!int.TryParse(args[0], out _userId))
        {
            _error = "ID must be an integer.";
            return;
        }

        if (!_service.ContainsUser(_userId))
        {
            _error = $"User with Id {_userId} not found.";
            return;
        }

        _service.DeleteUser(_userId);
    }

    public override string ToString()
    {
        string result = _error == string.Empty
            ? $"User with Id {_userId} deleted successfully."
            : _error;
        _error = string.Empty;
        return result;
    }
}