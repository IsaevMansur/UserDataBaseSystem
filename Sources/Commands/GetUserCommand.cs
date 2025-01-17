using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Mapping;

namespace UserDBService.Sources.Commands;

public class GetUserCommand : IUserCommand
{
    private readonly IUserService _service;
    private string _error = string.Empty;
    private string? _result;


    public GetUserCommand(IUserService service)
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

        if (args.Length < 1)
        {
            _error = "Usage: get <Id>.";
            return;
        }

        if (!long.TryParse(args[0], out long id))
        {
            _error = "Id must be an integer.";
            return;
        }

        if (!_service.ContainsUser(id))
        {
            _error = $"User with id {id} not found.";
            return;
        }

        var dto = _service.GetUser(id);
        var model = DtoToModel.Map(dto);
        model.Id = id;
        _result = model.ToString();
    }

    public override string ToString()
    {
        string result = _error == string.Empty && _result is not null
            ? _result
            : _error;
        _error = string.Empty;
        return result;
    }
}