using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Models;
using UserDBService.Sources.Models.Dto.Requests;

namespace UserDBService.Sources.Mapping;

// ReSharper disable once ClassNeverInstantiated.Global
public class ModelToDto : IMapper<UserModel, UserDto>
{
    public static UserDto Map(UserModel? from)
    {
        ArgumentNullException.ThrowIfNull(from);

        var builder = new UserBuilder()
            .SetFirstName(from.FirstName)
            .SetLastName(from.LastName)
            .SetPhone(from.Phone)
            .SetEmail(from.Email);
        var build = builder.Build();

        if (build.Model == null)
            throw new ArgumentNullException(build.Error);
        var model = build.Model;

        var dto = new UserDto
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Phone = model.Phone,
            Email = model.Email
        };
        return dto;
    }
}