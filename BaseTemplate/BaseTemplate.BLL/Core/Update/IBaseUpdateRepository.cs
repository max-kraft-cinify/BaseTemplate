namespace BaseTemplate.BLL.Core.Update;

public interface IBaseUpdateRepository<TEntityDto>
{
    TEntityDto Update(TEntityDto entityToUpdate);
}