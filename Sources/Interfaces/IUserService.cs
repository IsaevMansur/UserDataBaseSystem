namespace UserDBService.Sources.Interfaces;

public interface IUserService
{
    public long Count { get; }
    public void AddUser(IUserModel userModel);
    public IUserModel GetUser(long id);
    public IEnumerable<IUserModel>? GetAllUsers();
    public void UpdateUser(long id, IUserModel userModel);
    public void DeleteUser(long id);
    public bool UserExistsById(long id, out IUserModel? user);
}