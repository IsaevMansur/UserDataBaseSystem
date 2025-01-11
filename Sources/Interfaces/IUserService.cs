using UserDBService.Sources.Interfaces.User;

namespace UserDBService.Sources.Interfaces.Service;

public interface IUserService
{
    public void AddUser(IUserModel userModel);
    public IUserModel GetUser(int id);
    public IEnumerable<IUserModel> GetAllUsers();
    public void UpdateUser(int id, IUserModel userModel);
    public void DeleteUser(int id);
}