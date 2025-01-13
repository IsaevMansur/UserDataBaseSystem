using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Services;

public class DefaultUserService : IUserService
{
    private long _currentUserId;
    private readonly Dictionary<long, IUserModel> _users = [];
    public long Count => _users.Count;

    public void AddUser(IUserModel userModel)
    {
        ArgumentNullException.ThrowIfNull(userModel);

        if (!ValidationHelper.IsValidName(userModel.FirstName))
            throw new ArgumentException("The first name must contain at least 2 letters.");

        if (!ValidationHelper.IsValidName(userModel.LastName))
            throw new ArgumentException("The last name must contain at least 2 letters.");

        if (!ValidationHelper.IsValidEmail(userModel.Email))
            throw new ArgumentException(
                $"Email is not valid:{userModel.Email} sample: {ValidationHelper.EmailSample}.");

        if (!ValidationHelper.IsValidNumber(userModel.Phone))
            throw new ArgumentException(
                $"Phone is not valid:{userModel.Phone} sample: {ValidationHelper.PhoneSample}.");

        userModel.Id = _currentUserId++;
        _users.Add(userModel.Id, userModel);
    }


    public IUserModel GetUser(long id)
    {
        if (_users.TryGetValue(id, out var user))
            return user;

        throw new KeyNotFoundException($"User with id: {id} was not found.");
    }

    public IEnumerable<IUserModel> GetAllUsers()
    {
        return _users.Values;
    }

    public void UpdateUser(long id, IUserModel userModel)
    {
        ArgumentNullException.ThrowIfNull(userModel);
        TryGetUserById(id, out var user);

        if (user == null)
            throw new KeyNotFoundException($"User with Id: {id} not found.");

        user.FirstName = userModel.FirstName;
        user.LastName = userModel.LastName;
        user.Email = userModel.Email;
        user.Phone = userModel.Phone;
    }

    public void DeleteUser(long id)
    {
        if (_users.TryGetValue(id, out _))
        {
            throw new KeyNotFoundException($"User with Id: {id} not found.");
        }

        _users.Remove(id);
    }

    public bool TryGetUserById(long id, out IUserModel? user)
    {
        return _users.TryGetValue(id, out user);
    }
}