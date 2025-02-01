using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Interfaces.Models;

namespace UserDBService.Sources.Models;

public class UserBuilder : IUserBuilder
{
    private readonly UserModel _user = new();

    public UserModel Build()
    {
        return _user;
    }

    public IUserBuilder SetFirstName(string firstName)
    {
        _user.FirstName = firstName;
        return this;
    }

    public IUserBuilder SetLastName(string lastName)
    {
        _user.LastName = lastName;
        return this;
    }

    public IUserBuilder SetPhone(string phone)
    {
        _user.Phone = phone;
        return this;
    }

    public IUserBuilder SetEmail(string email)
    {
        _user.Email = email;
        return this;
    }
}