using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Mapping;
using UserDBService.Sources.Models.Dto.Requests;

namespace UserDBService.Sources.Services;

public class DefaultService : IUserService
{
    private readonly IUserDb _usersDatabase;
    private readonly DtoToModel _toModel = new();
    public long Count => _usersDatabase.Count;

    public DefaultService(IUserDb usersDatabase)
    {
        _usersDatabase = usersDatabase;
    }

    public void AddUser(UserDto model)
    {
        ArgumentNullException.ThrowIfNull(model);

        var user = _toModel.Map(model);
        ArgumentNullException.ThrowIfNull(user.Model);
        _usersDatabase.Add(user.Model);
    }

    public IUserModel GetUser(long id)
    {
        return _usersDatabase.Get(id) ?? throw new KeyNotFoundException($"User with id: {id} was not found.");
    }

    public IEnumerable<IUserModel> GetAllUsers()
    {
        return _usersDatabase.GetAll() ?? throw new Exception($"Database is empty.");
    }

    public void UpdateUser(long id, UserDto vice)
    {
        ArgumentNullException.ThrowIfNull(vice);

        if (ExistsUser(id, out _))
        {
            var user = _toModel.Map(vice);
            ArgumentNullException.ThrowIfNull(user.Model);
            _usersDatabase.Update(id, user.Model);
        }

        throw new KeyNotFoundException($"User with Id: {id} not found.");
    }

    public void DeleteUser(long id)
    {
        if (ExistsUser(id, out _))
            _usersDatabase.Remove(id);

        throw new KeyNotFoundException($"User with Id: {id} not found.");
    }

    public bool ExistsUser(long id, out IUserModel? user)
    {
        user = null;
        if (_usersDatabase.Exists(id))
            user = _usersDatabase.Get(id);

        return user is not null;
    }
}