namespace BaseTemplate.PAL.Core.FindById;

public interface IBaseFindByIdService<TEntity>
{
    TEntity FindById(int id);
}