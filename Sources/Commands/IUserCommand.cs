namespace UserDBService.Sources.Commands;

public interface IUserCommand
{
    public string Execute(string[] args);
}