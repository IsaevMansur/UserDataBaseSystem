namespace UserDBService.Sources.Interfaces;

public interface IUserCommand
{
    public string Execute(string[] args);
}