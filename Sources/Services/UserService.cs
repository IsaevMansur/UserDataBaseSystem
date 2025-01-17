using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Mapping;
using UserDBService.Sources.Models.Dto.Requests;
using UserDBService.Sources.Repositories;

namespace UserDBService.Sources.Services;

public class UserService : IUserService
{
    private readonly UserRepository _usersDatabase = new();
    public long Count => _usersDatabase.Count;

    public void AddUser(UserDto model)
    {
        var user = DtoToModel.Map(model);
        _usersDatabase.Add(user);
    }

    public UserDto GetUser(long id)
    {
        var user = _usersDatabase.Get(id);
        ArgumentNullException.ThrowIfNull(user, "Service can't find user");

        UserDto dto = ModelToDto.Map([user.FirstName, user.LastName, user.Phone, user.Email]);
        return dto;
    }

    public IEnumerable<IUserModel> GetAllUsers()
    {
        return _usersDatabase.GetAll() ?? throw new InvalidOperationException("Service can't find users");
    }

    public void UpdateUser(long id, UserDto vice)
    {
        var model = DtoToModel.Map(vice);
        model.Id = id;
        _usersDatabase.Update(id, model);
    }

    public void DeleteUser(long id)
    {
        _usersDatabase.Remove(id);
    }

    public bool ContainsUser(long id) => _usersDatabase.Contains(id);
}