namespace UserDBService.Sources.Interfaces;

public interface IMapper<TFrom, TTo>
{
    public static TTo Map(TFrom from)
    {
        throw new NotImplementedException();
    }
}