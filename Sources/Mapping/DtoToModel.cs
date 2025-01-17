using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Models;
using UserDBService.Sources.Models.Dto.Requests;

namespace UserDBService.Sources.Mapping;

public abstract class DtoToModel : IMapper<UserDto, IUserModel>
{
    public static UserModel Map(UserDto from)
    {
        var builder = new UserBuilder()
            .SetFirstName(from.FirstName)
            .SetLastName(from.LastName)
            .SetPhone(from.Phone)
            .SetEmail(from.Email);
        var build = builder.Build();

        if (build.Model == null)
            throw new ArgumentNullException(nameof(from), "Building model finish with error");
        return build.Model;
    }
}