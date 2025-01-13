namespace UserDBService.Sources.Utils;

public static class ArgsValidationHelper
{
    public static bool IsValidArgs(string[] args, byte count, string message)
    {
        if (args.Length != count)
        {
            Console.WriteLine(message);
            return false;
        }

        return true;
    }
}