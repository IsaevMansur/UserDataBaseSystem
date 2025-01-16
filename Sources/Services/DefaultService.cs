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
        var user = _toModel.Map(model);
        _usersDatabase.Add(user);
    }

    public IUserModel GetUser(long? id)
    {
        if (!id.HasValue)
            throw new ArgumentNullException(nameof(id));
        return _usersDatabase.Get((long)id) ?? throw new InvalidOperationException();
    }

    public IEnumerable<IUserModel> GetAllUsers()
    {
        return _usersDatabase.GetAll() ?? throw new Exception("Database is empty.");
    }

    public void UpdateUser(long? id, UserDto vice)
    {
        if (!id.HasValue)
            throw new ArgumentNullException(nameof(id));
        if (_usersDatabase.Contains((long)id))
        {
            var user = _toModel.Map(vice);
            _usersDatabase.Update((long)id, user);
        }

        throw new KeyNotFoundException($"User with Id: {id} not found.");
    }

    public void DeleteUser(long? id)
    {
        if (!id.HasValue)
            throw new ArgumentNullException(nameof(id));

        _usersDatabase.Remove((long)id);
    }

    public bool TryGetUser(long id, out IUserModel? user)
    {
        user = null;
        if (_usersDatabase.Contains(id))
            user = _usersDatabase.Get(id);

        return user is not null;
    }
}