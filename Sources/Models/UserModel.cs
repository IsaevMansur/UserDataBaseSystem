using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Models;

public class UserModel : IUserModel
{
    public UserModel()
    {
        FirstName = "default";
        LastName = "default";
        Phone = "default";
        Email = "default";
    }

    public UserModel(string firstName, string lastName, string phone, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
        Email = email;
    }

    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"{Id}\t\t{LastName}\t\t{Email}";
    }
}