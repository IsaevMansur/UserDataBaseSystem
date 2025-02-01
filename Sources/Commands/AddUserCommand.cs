using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Mapping;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Commands;

public class AddUserCommand : IUserCommand
{
    private readonly IUserService _service;

    public AddUserCommand(IUserService service) => _service = service;

    public string Execute(string[] args)
    {
        if (args.Length < 4)
            return "Usage: new <FirstName> <LastName> <Phone> <Email>";

        if (!ValidationUtil.IsValidUserAddDetails(args))
            return "Invalid arguments. Usage: new <FirstName> <LastName> <Phone> <Email>";

        var dto = Mapper.ToUserDto(args);

        _service.AddUser(dto);
        return "User added successfully";
    }
}