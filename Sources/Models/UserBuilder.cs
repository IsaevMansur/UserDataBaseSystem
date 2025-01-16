using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Models;

public class UserBuilder : IUserBuilder
{
    private readonly UserModel _user = new();
    private Result<UserModel> _result = Result<UserModel>.Success(new UserModel());


    public Result<UserModel> Build()
    {
        return _result is { IsSuccess: true }
            ? Result<UserModel>.Success(_user)
            : Result<UserModel>.Failure(_result.Error);
    }

    public IUserBuilder SetFirstName(string firstName)
    {
        if (!_result.IsSuccess) return this;
        if (!ValidationUtil.IsValidName(firstName))
        {
            _result = Result<UserModel>.Failure("The first name must contain at least 2 letters.");
            return this;
        }

        _user.FirstName = firstName;
        return this;
    }

    public IUserBuilder SetLastName(string lastName)
    {
        if (!_result.IsSuccess) return this;
        if (!ValidationUtil.IsValidName(lastName))
        {
            _result = Result<UserModel>.Failure("The last name must contain at least 2 letters.");
            return this;
        }

        _user.LastName = lastName;
        return this;
    }

    public IUserBuilder SetPhone(string phone)
    {
        if (!_result.IsSuccess) return this;
        if (!ValidationUtil.IsValidPhone(phone))
        {
            _result = Result<UserModel>.Failure($"Invalid number format, example: {ValidationUtil.PhoneSample}");
            return this;
        }

        _user.Phone = phone;
        return this;
    }

    public IUserBuilder SetEmail(string email)
    {
        if (!_result.IsSuccess) return this;
        if (!ValidationUtil.IsValidEmail(email))
        {
            _result = Result<UserModel>.Failure($"Invalid email format, example: {ValidationUtil.EmailSample}");
            return this;
        }

        _user.Email = email;
        return this;
    }
}