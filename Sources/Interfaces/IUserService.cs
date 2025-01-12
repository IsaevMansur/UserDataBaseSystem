namespace UserDBService.Sources.Interfaces;

public interface IUserService
{
    public void AddUser(IUserModel userModel);
    public IUserModel GetUser(int id);
    public IEnumerable<IUserModel> GetAllUsers();
    public void UpdateUser(int id, IUserModel userModel);
    public void DeleteUser(int id);
    public bool TryGetUserById(int id, out IUserModel? user);
}