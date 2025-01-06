namespace BaseTemplate.PAL.Core.Read;

public interface IBaseReadService<TEntity>
{
    TEntity Read();
}