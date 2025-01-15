using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class DeleteUserCommand : IUserCommand
{
    private readonly IUserService _service;
    private int _userId;
    private bool _isDeleted;

    public DeleteUserCommand(IUserService service)
    {
        _service = service;
    }


    public void Execute(string[] args)
    {
        if (!ValidationUtil.IsValidArgs(args, 1, "Usage: delete-user {userId}") ||
            !int.TryParse(args[0], out _userId))
        {
            return;
        }

        _isDeleted = _service.UserExistsById(_userId, out _);
        if (_isDeleted) _service.DeleteUser(_userId);
    }

    public override string ToString()
    {
        return _isDeleted ? $"User with Id {_userId} deleted successfully." : $"User with Id {_userId} not found.";
    }
}