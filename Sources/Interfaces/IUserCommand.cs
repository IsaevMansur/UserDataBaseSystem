namespace UserDBService.Sources.Interfaces;

public interface IUserCommand
{
    public void Execute(string[] args);
}