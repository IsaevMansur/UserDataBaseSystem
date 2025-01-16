using System.ComponentModel.DataAnnotations;

// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace UserDBService.Sources.Models.Dto.Requests;

public class UserDto
{
    [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
    public required string FirstName { get; set; }

    [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
    public required string LastName { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    [StringLength(100, ErrorMessage = "Email must not exceed 100 characters.")]
    public required string Email { get; set; }

    [Phone(ErrorMessage = "Invalid phone number format.")]
    [StringLength(10, ErrorMessage = "Phone number must not exceed 10 characters.")]
    public required string Phone { get; set; }
}