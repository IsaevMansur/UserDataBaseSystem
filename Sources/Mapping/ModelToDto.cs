using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Models;
using UserDBService.Sources.Models.Dto.Requests;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Mapping;

public class ModelToDto : IMapper<UserModel, UserDto>
{
    public Result<UserDto> Map(UserModel? from)
    {
        if (from == null)
            return Result<UserDto>.Failure("Model is null");

        var builder = new UserBuilder()
            .SetFirstName(from.FirstName)
            .SetLastName(from.LastName)
            .SetPhone(from.Phone)
            .SetEmail(from.Email);
        var model = builder.Build().Model;

        if (model == null)
            return Result<UserDto>.Failure("User model is invalid");

        var dto = new UserDto
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Phone = model.Phone,
            Email = model.Email
        };
        return Result<UserDto>.Success(dto);
    }
}