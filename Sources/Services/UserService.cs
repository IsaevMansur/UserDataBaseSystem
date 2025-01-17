using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Mapping;
using UserDBService.Sources.Models.Dto.Requests;

namespace UserDBService.Sources.Services;

public class UserService : IUserService
{
    private readonly IUserDb _usersDatabase;
    public long Count => _usersDatabase.Count;

    public UserService(IUserDb usersDatabase)
    {
        _usersDatabase = usersDatabase;
    }

    public void AddUser(UserDto model)
    {
        var user = DtoToModel.Map(model);
        _usersDatabase.Add(user);
    }

    public UserDto GetUser(long id)
    {
        var user = _usersDatabase.Get(id);

        if (user is not null)
        {
            UserDto dto = ModelToDto.Map([user.FirstName, user.LastName, user.Phone, user.Email]);
            return dto;
        }

        throw new InvalidOperationException();
    }

    public IEnumerable<IUserModel> GetAllUsers()
    {
        return _usersDatabase.GetAll() ?? throw new InvalidOperationException();
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