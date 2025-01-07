namespace BaseTemplate.BLL.Core.Delete;

public interface IBaseDeleteRepository<TEntityDto>
{
    bool Delete(TEntityDto entityToDelete);
}