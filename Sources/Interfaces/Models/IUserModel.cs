using UserDBService.Sources.Models;

namespace UserDBService.Sources.Interfaces.Models;

public interface IUserModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public static UserBuilder CreateBuilder() => new();
    public string ToString();
}