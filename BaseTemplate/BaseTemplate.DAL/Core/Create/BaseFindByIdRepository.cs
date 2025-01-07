using AutoMapper;
using BaseTemplate.BLL.Core.FindById;

namespace BaseTemplate.DAL.Core.Create;

public class BaseFindByIdRepository<TEntityDto, TDbEntity> : IBaseFindByIdRepository<TEntityDto> where TDbEntity : new()
{
    private IMapper _mapper;

    public BaseFindByIdRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TEntityDto FindById(int id)
    {
        var dbEntity = new TDbEntity();
        // TODO: Implement function
        return _mapper.Map<TEntityDto>(dbEntity);
    }
}