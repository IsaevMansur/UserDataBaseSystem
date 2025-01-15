using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Models;

public class UserBuilder : IUserBuilder
{
    private readonly UserModel _user = new();
    private string _error = string.Empty;

    public (UserModel? model, string error) Build()
    {
        return (string.IsNullOrEmpty(_error) ? _user : null, _error);
    }

    public void SetFirstName(string firstName)
    {
        if (!ValidationUtil.IsValidName(firstName))
        {
            _error = "The first name must contain at least 2 letters.";
            return;
        }

        _user.FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        if (!ValidationUtil.IsValidName(lastName))
        {
            _error = "The last name must contain at least 2 letters.";
            return;
        }

        _user.LastName = lastName;
    }

    public void SetPhone(string phone)
    {
        if (!ValidationUtil.IsValidPhone(phone))
        {
            _error = $"Invalid number format, example: {ValidationUtil.PhoneSample}";
            return;
        }

        _user.Phone = phone;
    }

    public void SetEmail(string email)
    {
        if (!ValidationUtil.IsValidEmail(email))
        {
            _error = $"Invalid email format, example: {ValidationUtil.EmailSample}";
            return;
        }

        _user.Email = email;
    }
}