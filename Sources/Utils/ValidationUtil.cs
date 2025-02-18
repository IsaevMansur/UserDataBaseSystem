using System.Text.RegularExpressions;

namespace UserDBService.Sources.Utils;

public static partial class ValidationUtil
{
    private static readonly Regex EmailRegex = EmailValidFormat();

    private static bool IsValidEmail(string email)
    {
        return !string.IsNullOrWhiteSpace(email) && EmailRegex.IsMatch(email);
    }

    private static bool IsValidPhone(string phone)
    {
        return !string.IsNullOrEmpty(phone) && phone.All(char.IsDigit) && phone.Length == 10;
    }

    private static bool IsValidName(string name)
    {
        return !string.IsNullOrEmpty(name) && name.Length > 1 && name.All(char.IsLetter);
    }

    public static bool IsValidUserAddDetails(string[] details, out string error)
    {
        if (!IsValidName(details[0]))
        {
            error = "Name is invalid";
            return false;
        }

        if (!IsValidName(details[1]))
        {
            error = "Invalid user last name";
            return false;
        }

        if (!IsValidEmail(details[2]))
        {
            error = "Invalid email";
            return false;
        }

        if (!IsValidPhone(details[3]))
        {
            error = "Invalid phone number";
            return false;
        }

        error = "";
        return true;
    }

    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        RegexOptions.IgnoreCase | RegexOptions.Compiled, "ru-RU")]
    private static partial Regex EmailValidFormat();
}