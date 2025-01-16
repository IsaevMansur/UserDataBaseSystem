namespace UserDBService.Sources.Interfaces;

public interface IMapper<in TFrom, out TTo>
{
    public static TTo Map(TFrom from)
    {
        throw new NotImplementedException();
    }
}