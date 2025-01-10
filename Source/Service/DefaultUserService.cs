using UserDBService.Source.Interface;
using UserDBService.Source.Util;

namespace UserDBService.Source.Service;

public class DefaultUserService : IUserService
{
    private readonly List<IUser> _users = [];
    private int _currentUserId = 1;

    public void AddUser(IUser user)
    {
        ArgumentNullException.ThrowIfNull(user);

        if (ValidationHelper.IsValidEmail(user.Email))
            throw new ArgumentException($"Email not contains a '@' character.");
        if (ValidationHelper.IsValidPhoneNumber(user.PhoneNumber))
            throw new ArgumentException($"Phone number is not contains a digit or is null");

        user.Id = _currentUserId++;
        _users.Add(user);
    }

    public IUser GetUser(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id)
               ?? throw new KeyNotFoundException($"User with Id: {id} not found.");
    }

    public IEnumerable<IUser> GetAllUsers()
    {
        return _users;
    }

    public void UpdateUser(int id, IUser updatedUser)
    {
        ArgumentNullException.ThrowIfNull(updatedUser);
        var user = GetUser(id);

        user.FirstName = updatedUser.FirstName;
        user.LastName = updatedUser.LastName;
        user.Email = updatedUser.Email;
        user.PhoneNumber = updatedUser.PhoneNumber;
    }

    public void DeleteUser(int id)
    {
        var user = GetUser(id);
        _users.Remove(user);
    }
}