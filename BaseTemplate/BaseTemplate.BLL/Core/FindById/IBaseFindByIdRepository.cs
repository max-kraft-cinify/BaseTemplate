namespace BaseTemplate.BLL.Core.FindById;

public interface IBaseFindByIdRepository<TEntityDto>
{
    TEntityDto FindById(int id);
}