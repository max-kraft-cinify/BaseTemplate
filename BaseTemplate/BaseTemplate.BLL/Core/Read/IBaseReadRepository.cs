namespace BaseTemplate.BLL.Core.Read;

public interface IBaseReadRepository<TEntityDto>
{
    TEntityDto Read();
}