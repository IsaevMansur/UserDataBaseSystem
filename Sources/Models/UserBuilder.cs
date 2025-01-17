using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Models;

public class UserBuilder : IUserBuilder
{
    private readonly UserModel _user = new();
    private string? _error;


    public Result<UserModel> Build()
    {
        return string.IsNullOrEmpty(_error)
            ? Result<UserModel>.Success(_user)
            : Result<UserModel>.Failure(_error);
    }

    public IUserBuilder SetFirstName(string firstName)
    {
        if (!string.IsNullOrEmpty(_error)) return this;
        if (!ValidationUtil.IsValidName(firstName))
        {
            _error = "The first name must contain at least 2 letters.";
            return this;
        }

        _user.FirstName = firstName;
        return this;
    }

    public IUserBuilder SetLastName(string lastName)
    {
        if (!string.IsNullOrEmpty(_error)) return this;
        if (!ValidationUtil.IsValidName(lastName))
        {
            _error = "The last name must contain at least 2 letters.";
            return this;
        }

        _user.LastName = lastName;
        return this;
    }

    public IUserBuilder SetPhone(string phone)
    {
        if (!string.IsNullOrEmpty(_error)) return this;
        if (!ValidationUtil.IsValidPhone(phone))
        {
            _error = $"Invalid number format, example: {ValidationUtil.PhoneSample}";
            return this;
        }

        _user.Phone = phone;
        return this;
    }

    public IUserBuilder SetEmail(string email)
    {
        if (!string.IsNullOrEmpty(_error)) return this;
        if (!ValidationUtil.IsValidEmail(email))
        {
            _error = $"Invalid email format, example: {ValidationUtil.EmailSample}";
            return this;
        }

        _user.Email = email;
        return this;
    }
}