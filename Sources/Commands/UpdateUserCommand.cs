using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Mapping;
using UserDBService.Sources.Models;
using UserDBService.Sources.Utils;

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
        if (!ValidationUtil.IsValidId(args[0]))
            return;

        var userData = ExtractUserData(args);

        ModelToDto dtoRequest = new ModelToDto();
        var dto = dtoRequest.Map(new UserModel(userData.FirstName,
            userData.LastName,
            userData.Phone,
            userData.Email));

        if (dto.Model == null)
        {
            _error = dto.Error + '\n' + "Usage: update <Id> <FirstName> <LastName> <Phone> <Email>";
            return;
        }

        _service.UpdateUser(id: long.Parse(userData.Id), vice: dto.Model);
    }

    public override string ToString()
    {
        return _error == string.Empty ? "User by id updated successfully." : _error;
    }

    // ReSharper disable once MemberCanBeMadeStatic.Local
    private (string Id, string FirstName, string LastName, string Phone, string Email) ExtractUserData(
        string[] args)
    {
        return (args[0], args[1], args[2], args[3], args[4]);
    }
}