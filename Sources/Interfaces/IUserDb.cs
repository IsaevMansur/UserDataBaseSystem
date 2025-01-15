namespace UserDBService.Sources.Interfaces;

public interface IUserDb
{
    public long Count { get; }
    public void Add(IUserModel user);
    public IUserModel? Get(long id);
    public IEnumerable<IUserModel>? GetAll();
    public void Remove(long id);
    public void Update(long id, IUserModel user);
}