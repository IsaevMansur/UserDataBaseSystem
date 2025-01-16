using UserDBService.Sources.Models.Dto.Requests;

namespace UserDBService.Sources.Interfaces;

public interface IUserService
{
    public long Count { get; }
    public void AddUser(UserDto model);
    public IUserModel GetUser(long id);
    public IEnumerable<IUserModel>? GetAllUsers();
    public void UpdateUser(long id, UserDto vice);
    public void DeleteUser(long id);
    public bool ExistsUser(long id, out IUserModel? user);
}