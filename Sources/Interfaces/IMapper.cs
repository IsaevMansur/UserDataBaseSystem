using UserDBService.Sources.Utils;

namespace UserDBService.Sources.Interfaces;

public interface IMapper<in TFrom, TTo>
{
    Result<TTo> Map(TFrom from);
}