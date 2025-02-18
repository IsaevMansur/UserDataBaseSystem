namespace UserDBService.Sources.Models;

public class UserModel : IUserModel
{
    private UserModel()
    {
    }

    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public static UserBuilder CreateBuilder()
    {
        return new UserBuilder();
    }

    public override string ToString()
    {
        return $"{Id}:{LastName}:{Email}";
    }

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
}