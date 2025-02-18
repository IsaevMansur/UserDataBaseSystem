using UserDBService.Sources.Models;

namespace UserDBService.Sources.Repositories;

public class MemoryUserRepository : IUserRepository
{
    private readonly Dictionary<long, IUserModel> _userDb = new();
    private long _currentUserId = 1;
    public long Count => _userDb.Count;

    public void Create(IUserModel user)
    {
        user.Id = _currentUserId++;
        _userDb.Add(user.Id, user);
    }

    public IUserModel Read(long id)
    {
        return _userDb[id];
    }

    public void Update(long id, IUserModel user)
    {
        user.Id = id;
        _userDb[id] = user;
    }

    public void Remove(long id)
    {
        _userDb.Remove(id);
    }

    public bool Contains(long id)
    {
        return _userDb.ContainsKey(id);
    }

    public IEnumerable<IUserModel> GetAll()
    {
        return _userDb.Values;
    }
}