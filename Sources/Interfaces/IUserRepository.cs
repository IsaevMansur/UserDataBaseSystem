namespace UserDBService.Sources.Interfaces;

public interface IUserRepository
{
    public long Count { get; }
    public void Add(IUserModel user);
    public IUserModel? Get(long id);
    public IEnumerable<IUserModel>? GetAll();
    public void Remove(long id);
    public void Update(long id, IUserModel user);
    public bool Contains(long id);
}