using System.Text.RegularExpressions;

namespace UserDBService.Sources.Utils;

public static class ValidationHelperUtil
{
    public const string EmailSample = "example@gmail.com";
    public const string PhoneNumberSample = "89122123456";

    private static readonly Regex EmailRegex = new(
        @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public static bool IsValidEmail(string email) =>
        !string.IsNullOrWhiteSpace(email) && EmailRegex.IsMatch(email);

    public static bool IsValidNumber(string phoneNumber) =>
        !string.IsNullOrEmpty(phoneNumber) && phoneNumber.All(char.IsDigit) && phoneNumber.Length == 10;

    public static bool IsValidName(string name) =>
        !string.IsNullOrEmpty(name) && name.Length >= 2 && name.All(char.IsLetter);
}