using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Models;
using UserDBService.Sources.Models.Dto.Requests;

namespace UserDBService.Sources.Mapping;

public class DtoToModel : IMapper<UserDto, UserModel>
{
    public UserModel Map(UserDto? from)
    {
        ArgumentNullException.ThrowIfNull(from);

        var builder = new UserBuilder()
            .SetFirstName(from.FirstName)
            .SetLastName(from.LastName)
            .SetPhone(from.Phone)
            .SetEmail(from.Email);
        var build = builder.Build();

        if (build.Model == null)
            throw new NullReferenceException(build.Error);
        return build.Model;
    }
}