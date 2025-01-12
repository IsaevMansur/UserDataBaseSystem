using UserDBService.Sources.Interfaces;
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
            throw new ArgumentException(
                $"Email is not valid:{userModel.Email} sample: {ValidationHelper.EmailSample}.");
        if (!ValidationHelper.IsValidNumber(userModel.Phone))
            throw new ArgumentException(
                $"Phone is not valid:{userModel.Phone} sample: {ValidationHelper.PhoneSample}.");

        userModel.Id = _currentUserId++;
        _users.Add(userModel);
    }

    public IUserModel GetUser(int id)
    {
        int start = 0;
        int end = _users.Count - 1;
        IUserModel? target = null;

        while (start <= end)
        {
            int mid = (start + end) / 2;
            if (_users[mid].Id == id)
                target = _users[mid];
            if (_users[mid].Id > id)
                end = mid - 1;
            else
                start = mid + 1;
        }

        return target ?? throw new KeyNotFoundException($"User with Id: {id} not found.");
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
        user.Phone = updatedUserModel.Phone;
    }

    public void DeleteUser(int id)
    {
        var user = GetUser(id);
        _users.Remove(user);
    }

    public bool TryGetUserById(int id, out IUserModel? user)
    {
        int start = 0;
        int end = _users.Count - 1;
        user = null;

        while (start <= end)
        {
            int mid = (start + end) / 2;
            if (_users[mid].Id == id)
                user = _users[mid];
            if (_users[mid].Id > id)
                end = mid - 1;
            else
                start = mid + 1;
        }

        return user == null;
    }
}