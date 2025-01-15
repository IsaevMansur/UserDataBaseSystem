using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Services;

public class DefaultService : IUserService
{
    private readonly IUserDb _usersDatabase;
    public long Count => _usersDatabase.Count;

    public DefaultService(IUserDb usersDatabase)
    {
        _usersDatabase = usersDatabase;
    }

    public void AddUser(IUserModel userModel)
    {
        ArgumentNullException.ThrowIfNull(userModel);
        _usersDatabase.Add(userModel);
    }

    public IUserModel GetUser(long id)
    {
        return _usersDatabase.Get(id) ?? throw new KeyNotFoundException($"User with id: {id} was not found.");
    }

    public IEnumerable<IUserModel> GetAllUsers()
    {
        return _usersDatabase.GetAll() ?? throw new Exception($"Database is empty.");
    }

    public void UpdateUser(long id, IUserModel user)
    {
        ArgumentNullException.ThrowIfNull(user);

        if (ExistsUser(id, out _))
            _usersDatabase.Update(id, user);

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