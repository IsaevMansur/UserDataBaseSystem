﻿using UserDBService.Sources.Interfaces.Models;
using UserDBService.Sources.Models;
using UserDBService.Sources.Models.Dto.Requests;

namespace UserDBService.Sources.Mapping;

public class Mapper
{
    public static IUserModel ToUserModel(UserDto from)
    {
        IUserBuilder builder = UserModel
            .CreateBuilder()
            .SetFirstName(from.FirstName)
            .SetLastName(from.LastName)
            .SetPhone(from.Phone)
            .SetEmail(from.Email);

        return builder.Build();
    }

    public static UserDto ToUserDto(string[] from)
    {
        return new UserDto
        {
            FirstName = from[0],
            LastName = from[1],
            Phone = from[2],
            Email = from[3],
        };
    }
}
