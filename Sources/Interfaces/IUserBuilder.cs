using UserDBService.Sources.Models;

namespace UserDBService.Sources.Interfaces;

public interface IUserBuilder
{
    public (UserModel? model, string error) Build();
    public void SetFirstName(string firstName);
    public void SetLastName(string lastName);
    public void SetEmail(string email);
    public void SetPhone(string phone);
}