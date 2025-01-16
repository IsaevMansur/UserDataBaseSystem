using UserDBService.Sources.Interfaces;
using UserDBService.Sources.Models;
using UserDBService.Sources.Models.Dto.Requests;
using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Mapping;

public class DtoToModel : IMapper<UserDto, UserModel>
{
    public Result<UserModel> Map(UserDto? from)
    {
        if (from == null)
            return Result<UserModel>.Failure("UserDto is null");

        var builder = new UserBuilder()
            .SetFirstName(from.FirstName)
            .SetLastName(from.LastName)
            .SetPhone(from.Phone)
            .SetEmail(from.Email);
        var model = builder.Build().Model;

        return model == null ? Result<UserModel>.Failure("UserDto is null") : Result<UserModel>.Success(model);
    }
}