

// ReSharper disable PropertyCanBeMadeInitOnly.Global

namespace UserDBService.Sources.Models.Dto.Requests;

public class UserDto
{
    // [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
    public required string FirstName { get; set; }

    // [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
    public required string LastName { get; set; }

    // [EmailAddress(ErrorMessage = $"Invalid email address format. Valid format {ValidationUtil.EmailSample}")]
    // [StringLength(50, ErrorMessage = "Email must not exceed 50 characters.")]
    public required string Email { get; set; }

    // [Phone(ErrorMessage = $"Invalid phone number format. Valid format {ValidationUtil.PhoneSample}")]
    // [StringLength(10, ErrorMessage = "Phone number must be an integer and not exceed 10 characters.")]
    public required string Phone { get; set; }
}