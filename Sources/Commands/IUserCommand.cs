namespace UserDBService.Sources.Commands;

public abstract class UserCommandBase
{
    public abstract string Execute(string[] args);
}
