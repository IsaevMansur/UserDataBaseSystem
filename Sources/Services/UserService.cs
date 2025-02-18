using UserDBService.Sources.Mapping;
using UserDBService.Sources.Models;
using UserDBService.Sources.Models.Dto.Requests;
using UserDBService.Sources.Repositories;

namespace UserDBService.Sources.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _usersDatabase;

    public UserService(IUserRepository usersDatabase)
    {
        _usersDatabase = usersDatabase;
    }

    public long CountUsers => _usersDatabase.Count;

    public void AddUser(UserDto model)
    {
        var user = Mapper.ToUserModel(model);
        _usersDatabase.Create(user);
    }

    public UserDto GetUser(long id)
    {
        var user = _usersDatabase.Read(id);
        ArgumentNullException.ThrowIfNull(user, "Service can't find user");

        var dto = Mapper.ToUserDto([user.FirstName, user.LastName, user.Phone, user.Email]);
        return dto;
    }

    public IEnumerable<IUserModel> GetAllUsers()
    {
        var users = _usersDatabase.GetAll();
        ArgumentNullException.ThrowIfNull(users, "Service can't find users");
        return users;
    }

    public void UpdateUser(long id, UserDto vice)
    {
        var model = Mapper.ToUserModel(vice);
        model.Id = id;
        _usersDatabase.Update(id, model);
    }

    public void DeleteUser(long id)
    {
        _usersDatabase.Remove(id);
    }

    public bool ContainsUser(long id)
    {
        return _usersDatabase.Contains(id);
    }
}