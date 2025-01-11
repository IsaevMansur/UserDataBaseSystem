using UserDBService.Sources.Interfaces.Service;
using UserDBService.Sources.Interfaces.User;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Services;

public class UserService : IUserService
{
    private readonly List<IUserModel> _users = [];
    private int _currentUserId = 1;

    public void AddUser(IUserModel userModel)
    {
        ArgumentNullException.ThrowIfNull(userModel);

        if (!ValidationHelper.IsValidEmail(userModel.Email))
            throw new ArgumentException($"Email is not valid:{userModel.Email} sample: {ValidationHelper.EmailSample}.");
        if (!ValidationHelper.IsValidNumber(userModel.PhoneNumber))
            throw new ArgumentException(
                $"Phone is not valid:{userModel.PhoneNumber} sample: {ValidationHelper.PhoneNumberSample}.");

        userModel.Id = _currentUserId++;
        _users.Add(userModel);
    }

    public IUserModel GetUser(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id)
               ?? throw new KeyNotFoundException($"User with Id: {id} not found.");
    }

    public IEnumerable<IUserModel> GetAllUsers()
    {
        return _users;
    }

    public void UpdateUser(int id, IUserModel updatedUserModel)
    {
        ArgumentNullException.ThrowIfNull(updatedUserModel);
        var user = GetUser(id);

        user.FirstName = updatedUserModel.FirstName;
        user.LastName = updatedUserModel.LastName;
        user.Email = updatedUserModel.Email;
        user.PhoneNumber = updatedUserModel.PhoneNumber;
    }

    public void DeleteUser(int id)
    {
        var user = GetUser(id);
        _users.Remove(user);
    }

    public bool TryGetUserById(int userId, out IUserModel? user)
    {
        user = _users.FirstOrDefault(u => u.Id == userId);
        return user != null;
    }
}