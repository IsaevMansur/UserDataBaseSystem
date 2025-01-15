namespace UserDBService.Sources.Interfaces;

public interface IUserDb
{
    public long Count { get; }
    public void Add(IUserModel user);
    public IUserModel? GetById(long id);
    public IEnumerable<IUserModel>? GetAll();
    public void RemoveAtId(long id);
    public void UpdateAtId(long id, IUserModel user);
}