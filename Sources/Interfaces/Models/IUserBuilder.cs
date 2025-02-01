using UserDBService.Sources.Models;

namespace UserDBService.Sources.Interfaces.Models;

public interface IUserBuilder
{
    public UserModel Build();
    public IUserBuilder SetFirstName(string firstName);
    public IUserBuilder SetLastName(string lastName);
    public IUserBuilder SetEmail(string email);
    public IUserBuilder SetPhone(string phone);
}