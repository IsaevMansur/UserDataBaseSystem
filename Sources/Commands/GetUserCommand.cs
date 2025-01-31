using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Mapping;

namespace UserDBService.Sources.Commands;

public class GetUserCommand : IUserCommand
{
    private readonly IUserService _service;


    public GetUserCommand(IUserService service) => _service = service;

    public string Execute(string[] args)
    {
        if (_service.Count == 0)
            return "Base is empty.";

        if (args.Length < 1)
            return "Usage: get <Id>.";

        if (!long.TryParse(args[0], out long id))
            return "Id must be an integer.";

        if (!_service.ContainsUser(id))
            return $"User with id {id} not found.";

        var dto = _service.GetUser(id);
        var model = Mapper.ToUserModel(dto);
        model.Id = id;
        return model.ToString();
    }
}