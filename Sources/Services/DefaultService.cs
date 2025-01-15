using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Services;

public class DefaultService : IUserService
{
    private readonly IUserDb _inMemUsersDb;
    public long Count => _inMemUsersDb.Count;

    public DefaultService(IUserDb inMemUsersDb)
    {
        _inMemUsersDb = inMemUsersDb;
    }

    public void AddUser(IUserModel userModel)
    {
        ArgumentNullException.ThrowIfNull(userModel);
        _inMemUsersDb.Add(userModel);
    }


    public IUserModel GetUser(long id)
    {
        UserExistsById(id, out var user);
        if (user != null)
            return user;

        throw new KeyNotFoundException($"User with id: {id} was not found.");
    }

    public IEnumerable<IUserModel> GetAllUsers()
    {
        return _inMemUsersDb.GetAll() ?? throw new Exception($"Database is empty.");
    }

    public void UpdateUser(long id, IUserModel userModel)
    {
        ArgumentNullException.ThrowIfNull(userModel);
        UserExistsById(id, out var user);

        if (user == null)
            throw new KeyNotFoundException($"User with Id: {id} not found.");

        _inMemUsersDb.UpdateAtId(id, user);
    }

    public void DeleteUser(long id)
    {
        if (UserExistsById(id, out _))
            _inMemUsersDb.RemoveAtId(id);

        throw new KeyNotFoundException($"User with Id: {id} not found.");
    }

    public bool UserExistsById(long id, out IUserModel? user)
    {
        user = _inMemUsersDb.GetById(id);
        return user is not null;
    }
}