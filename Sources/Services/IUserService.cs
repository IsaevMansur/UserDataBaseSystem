using UserDBService.Sources.Interfaces.Models;
using UserDBService.Sources.Models.Dto.Requests;

namespace UserDBService.Sources.Services;

public interface IUserService
{
    public long CountUsers { get; }
    public void AddUser(UserDto model);
    public UserDto GetUser(long id);
    public IEnumerable<IUserModel>? GetAllUsers();
    public void UpdateUser(long id, UserDto vice);
    public void DeleteUser(long id);
    public bool ContainsUser(long id);
}