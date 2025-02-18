namespace UserDBService.Sources.Models;

public interface IUserModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public static UserModel.UserBuilder CreateUser()
    {
        return new UserModel.UserBuilder();
    }

    public string ToString();
}