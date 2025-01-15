using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Models;

public class UserModel : IUserModel
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{Id}\t\t{LastName}\t\t{Email}";
    }
}