namespace UserDBService.Source.Util;

public static class ValidationHelper
{
    public static bool IsValidEmail(string email) =>
        !string.IsNullOrEmpty(email) && email.Contains('@');

    public static bool IsValidPhoneNumber(string phoneNumber) =>
        !string.IsNullOrEmpty(phoneNumber) && phoneNumber.All(char.IsDigit);
}