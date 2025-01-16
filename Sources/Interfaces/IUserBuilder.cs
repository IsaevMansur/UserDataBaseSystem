using UserDBService.Sources.Models;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Interfaces;

public interface IUserBuilder
{
    public Result<UserModel> Build();
    public IUserBuilder SetFirstName(string firstName);
    public IUserBuilder SetLastName(string lastName);
    public IUserBuilder SetEmail(string email);
    public IUserBuilder SetPhone(string phone);
}