namespace BaseTemplate.PAL.Core.Delete;

public interface IBaseDeleteService<TEntity>
{
    bool Delete(TEntity entityToDelete);
}