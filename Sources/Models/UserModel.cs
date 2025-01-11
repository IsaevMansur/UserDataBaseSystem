using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Models;

public class UserModel : IUserModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"{Id}\t\t{LastName}\t\t{Email}";
    }

    public UserModel(string firstName, string lastName, string phoneNumber, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}