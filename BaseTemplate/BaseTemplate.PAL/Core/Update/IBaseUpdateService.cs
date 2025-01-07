namespace BaseTemplate.PAL.Core.Update;

public interface IBaseUpdateService<TEntity>
{
    TEntity Update(TEntity entityToUpdate);
}