namespace Shared.BLL.Core.Read;

public interface IBaseReadRepository<TEntity>
{
    TEntity Read();
}