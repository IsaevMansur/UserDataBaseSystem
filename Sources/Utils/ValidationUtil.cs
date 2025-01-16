using System.Text.RegularExpressions;

namespace UserDBService.Sources.Utils;

public static partial class ValidationUtil
{
    public const string EmailSample = "example@gmail.com";
    public const string PhoneSample = "9122123456";

    private static readonly Regex EmailRegex = EmailValidFormat();

    public static bool IsValidEmail(string email) =>
        !string.IsNullOrWhiteSpace(email) && EmailRegex.IsMatch(email);

    public static bool IsValidPhone(string phone) =>
        !string.IsNullOrEmpty(phone) && phone.All(char.IsDigit) && phone.Length == 10;

    public static bool IsValidName(string name) =>
        !string.IsNullOrEmpty(name) && name.Length >= 2 && name.All(char.IsLetter);

    public static bool IsValidId(string id) =>
        !string.IsNullOrEmpty(id) && id.All(char.IsDigit);

    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        RegexOptions.IgnoreCase | RegexOptions.Compiled, "ru-RU")]
    private static partial Regex EmailValidFormat();

    public static bool IsValidArgs(string[] args, byte count, string error)
    {
        if (args.Length != count)
        {
            Console.WriteLine(error);
            return false;
        }

        return true;
    }
}