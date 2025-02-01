using UserDBService.Sources.Interfaces.Models;

namespace UserDBService.Sources.Models;

public class UserModel : IUserModel
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public static UserBuilder CreateBuilder() => new();

    public override string ToString()
    {
        return $"{Id}:{LastName}:{Email}";
    }

}