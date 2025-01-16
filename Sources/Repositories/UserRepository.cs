using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Repositories;

public class UserRepository : IUserDb
{
    private readonly Dictionary<long, IUserModel> _userDb = new();
    private long _currentUserId = 1;
    public long Count => _userDb.Count;

    public void Add(IUserModel user)
    {
        user.Id = _currentUserId++;
        _userDb.Add(user.Id, user);
    }

    public IUserModel Get(long id) => _userDb[id];

    public bool Contains(long id) => _userDb.ContainsKey(id);

    public IEnumerable<IUserModel> GetAll() => _userDb.Values;

    public void Remove(long id) => _userDb.Remove(id);

    public void Update(long id, IUserModel user) => _userDb[id] = user;
}