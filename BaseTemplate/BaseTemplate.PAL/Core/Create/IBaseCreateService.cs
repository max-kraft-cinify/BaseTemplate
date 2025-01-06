namespace BaseTemplate.PAL.Core.Create;

public interface IBaseCreateService<TEntity>
{
    TEntity Create(TEntity entityToCreate);
}