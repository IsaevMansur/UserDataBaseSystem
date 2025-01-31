using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Mapping;

namespace UserDBService.Sources.Commands;

public class UpdateUserCommand : IUserCommand
{
    private readonly IUserService _service;

    public UpdateUserCommand(IUserService service) => _service = service;

    public string Execute(string[] args)
    {
        if (_service.Count == 0)
            return "Base is empty.";

        if (args.Length < 5)
            return "Usage: update <Id> <Firstname> <Lastname> <Phone> <Email>.";

        if (!long.TryParse(args[0], out long id))
            return "ID must be a number.";

        if (!_service.ContainsUser(id))
            return "User does not exist.";

        var dto = Mapper.ToUserDto(args[1..]);

        _service.UpdateUser(id, dto);
        return "User by id updated successfully.";
    }
}