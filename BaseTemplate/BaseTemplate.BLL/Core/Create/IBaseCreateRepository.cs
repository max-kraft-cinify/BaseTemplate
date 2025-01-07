namespace BaseTemplate.BLL.Core.Create;

public interface IBaseCreateRepository<TEntityDto>
{
    TEntityDto Create(TEntityDto entityToCreate);
}