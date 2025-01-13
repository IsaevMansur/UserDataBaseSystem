using System.Text.RegularExpressions;

namespace UserDBService.Sources.Utils;

public static class ValidationHelper
{
    public const string EmailSample = "example@gmail.com";
    public const string PhoneSample = "9122123456";

    private static readonly Regex EmailRegex = new(
        @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static bool IsValidEmail(string email) =>
        !string.IsNullOrWhiteSpace(email) && EmailRegex.IsMatch(email);


    public static bool IsValidNumber(string phone) =>
        !string.IsNullOrEmpty(phone) && phone.All(char.IsDigit) && phone.Length == 10;

    public static bool IsValidName(string name) =>
        !string.IsNullOrEmpty(name) && name.Length >= 2 && name.All(char.IsLetter);

    public static bool IsValidId(string id) =>
        !string.IsNullOrEmpty(id) && id.All(char.IsDigit);
}