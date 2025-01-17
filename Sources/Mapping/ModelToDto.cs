using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Models;
using UserDBService.Sources.Models.Dto.Requests;

namespace UserDBService.Sources.Mapping;

// ReSharper disable once ClassNeverInstantiated.Global
public class ModelToDto : IMapper<string[], UserDto>
{
    public static UserDto Map(string[]? from)
    {
        ArgumentNullException.ThrowIfNull(from);

        var builder = new UserBuilder()
            .SetFirstName(from[0])
            .SetLastName(from[1])
            .SetPhone(from[2])
            .SetEmail(from[3]);
        var build = builder.Build();

        if (build.Model is null)
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