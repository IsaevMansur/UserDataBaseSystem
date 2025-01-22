namespace UserDBService.Sources.Interfaces;

public interface IUserRepository
{
    public long Count { get; }
    public void Create(IUserModel user);
    public IUserModel? Read(long id);
    public void Update(long id, IUserModel user);
    public void Remove(long id);
    public IEnumerable<IUserModel>? GetAll();
    public bool Contains(long id);
}