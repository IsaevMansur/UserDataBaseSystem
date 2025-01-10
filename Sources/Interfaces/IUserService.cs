namespace UserDBService.Sources.Interfaces;

public interface IUserService
{
    public void AddUser(IUser user);
    public IUser GetUser(int id);
    public IEnumerable<IUser> GetAllUsers();
    public void UpdateUser(int id, IUser user);
    public void DeleteUser(int id);
}