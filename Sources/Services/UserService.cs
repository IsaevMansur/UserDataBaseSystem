using System.Runtime.CompilerServices;
using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Services;

public class UserService : IUserService
{
    private readonly List<IUserModel> _users = [];
    private long _currentUserId = 1;

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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IUserModel GetUser(long id)
    {
        int start = 0;
        int end = _users.Count - 1;

        while (start <= end)
        {
            int mid = (start + end) / 2;
            var currentUser = _users[mid];

            if (currentUser.Id == id)
                return currentUser;

            if (currentUser.Id > id)
                end = mid - 1;
            else
                start = mid + 1;
        }

        throw new KeyNotFoundException($"User with Id: {id} not found.");
    }


    public IEnumerable<IUserModel> GetAllUsers()
    {
        return _users;
    }

    public void UpdateUser(long id, IUserModel updatedUserModel)
    {
        ArgumentNullException.ThrowIfNull(updatedUserModel);
        TryGetUserById(id, out var user);

        if (user == null)
            throw new KeyNotFoundException($"User with Id: {id} not found.");

        user.FirstName = updatedUserModel.FirstName;
        user.LastName = updatedUserModel.LastName;
        user.Email = updatedUserModel.Email;
        user.Phone = updatedUserModel.Phone;
    }

    public void DeleteUser(long id)
    {
        int start = 0;
        int end = _users.Count - 1;

        while (start <= end)
        {
            int mid = (start + end) / 2;
            var currentUser = _users[mid];

            if (currentUser.Id == id)
            {
                _users.RemoveAt(mid);
                return;
            }

            if (currentUser.Id > id)
                end = mid - 1;
            else
                start = mid + 1;
        }

        throw new KeyNotFoundException($"User with Id: {id} not found.");
    }

    public bool TryGetUserById(long id, out IUserModel? user)
    {
        int start = 0;
        int end = _users.Count - 1;
        user = null;

        while (start <= end)
        {
            int mid = (start + end) / 2;
            var currentUser = _users[mid];

            if (currentUser.Id == id)
            {
                user = currentUser;
                return true;
            }

            if (currentUser.Id > id)
                end = mid - 1;
            else
                start = mid + 1;
        }

        return false;
    }
}