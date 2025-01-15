using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Repositories;

public class UserRepository : IUserDb
{
    private readonly Dictionary<long, IUserModel> _userDb = [];
    private long _currentUserId = 1;
    public long Count => _userDb.Count;

    public void Add(IUserModel user)
    {
        user.Id = _currentUserId++;
        _userDb.Add(user.Id, user);
    }

    public IUserModel? Get(long id) => _userDb.GetValueOrDefault(id);

    public IEnumerable<IUserModel> GetAll() => _userDb.Values;

    public void Remove(long id) => _userDb.Remove(id);

    public void Update(long id, IUserModel user) => _userDb[id] = user;
}