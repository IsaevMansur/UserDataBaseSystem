using UserDBService.Sources.Interfaces;

namespace UserDBService.Sources.Models;

public class DefaultUser : IUser
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public DefaultUser(string firstName, string lastName, string phoneNumber, string email)
    {
        Id = 1;
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}