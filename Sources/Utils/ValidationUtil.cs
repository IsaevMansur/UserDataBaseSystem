using System.Text.RegularExpressions;

namespace UserDBService.Sources.Utils;

public static partial class ValidationUtil
{
    // public const string EmailSample = "example@gmail.com";
    // public const string PhoneSample = "9122123456";

    private static readonly Regex EmailRegex = EmailValidFormat();

    private static bool IsValidEmail(string email) =>
        !string.IsNullOrWhiteSpace(email) && EmailRegex.IsMatch(email);

    private static bool IsValidPhone(string phone) =>
        !string.IsNullOrEmpty(phone) && phone.All(char.IsDigit) && phone.Length == 10;

    private static bool IsValidName(string name) =>
        !string.IsNullOrEmpty(name) && name.Length > 1 && name.All(char.IsLetter);

    public static bool IsValidUserAddDetails(string[] details)
    {
        return IsValidName(details[0]) && // first name
               IsValidName(details[1]) && // last name
               IsValidEmail(details[2]) && // email
               IsValidPhone(details[3]); // phone
    }

    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        RegexOptions.IgnoreCase | RegexOptions.Compiled, "ru-RU")]
    private static partial Regex EmailValidFormat();
}