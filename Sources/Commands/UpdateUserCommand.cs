using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Mapping;

namespace UserDBService.Sources.Commands;

public class UpdateUserCommand : IUserCommand
{
    private readonly IUserService _service;
    private string _error = string.Empty;

    public UpdateUserCommand(IUserService service)
    {
        _service = service;
    }

    public void Execute(string[] args)
    {
        if (_service.Count == 0)
        {
            _error = "Base is empty.";
            return;
        }

        if (args.Length < 5)
        {
            _error = "Usage: update <Id> <Firstname> <Lastname> <Phone> <Email>.";
            return;
        }

        if (!long.TryParse(args[0], out long id))
        {
            _error = "Id must be an integer.";
            return;
        }

        if (!_service.ContainsUser(id))
        {
            _error = "Id not found.";
            return;
        }

        var dto = ModelToDto.Map(args[1..]);

        _service.UpdateUser(id, dto);
    }

    public override string ToString()
    {
        string result = _error == string.Empty ? "User by id updated successfully." : _error;
        _error = string.Empty;
        return result;
    }
}