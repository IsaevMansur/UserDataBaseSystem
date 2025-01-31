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

        if (!ValidationUtil.IsValidName(args[0]))
            return "First name must be between 2 and 50 characters.";

        if (!ValidationUtil.IsValidName(args[1]))
            return "Last name must be between 2 and 50 characters.";

        if (!ValidationUtil.IsValidPhone(args[2]))
            return $"Invalid phone number format. Valid format {ValidationUtil.PhoneSample}";

        if (!ValidationUtil.IsValidEmail(args[3]))
            return $"Invalid email format. Valid format {ValidationUtil.EmailSample}";

        var dto = Mapper.ToUserDto(args);

        _service.AddUser(dto);
        return "User added successfully";
    }
}