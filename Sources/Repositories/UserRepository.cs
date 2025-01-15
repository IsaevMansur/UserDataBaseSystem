using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Repository;

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

    public IUserModel? GetById(long id) => _userDb.GetValueOrDefault(id);

    public IEnumerable<IUserModel> GetAll() => _userDb.Values;

    public void RemoveAtId(long id) => _userDb.Remove(id);

    public void UpdateAtId(long id, IUserModel user) => _userDb[id] = user;
}