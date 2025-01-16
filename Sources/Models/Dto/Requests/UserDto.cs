using System.ComponentModel.DataAnnotations;

namespace UserDBService.Sources.Models.Dto.Requests;

public class UserDto
{
    [StringLength(50, MinimumLength = 2)] public required string FirstName { get; set; }
    [StringLength(50, MinimumLength = 2)] public required string LastName { get; set; }
    [EmailAddress] public required string Email { get; set; }
    [Required] public required string Phone { get; set; }
}