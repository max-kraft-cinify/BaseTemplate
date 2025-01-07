using AutoMapper;
using BaseTemplate.BLL.Core.Create;

namespace BaseTemplate.DAL.Core.FindById;

public class BaseCreateRepository<TEntityDto, TDbEntity> : IBaseCreateRepository<TEntityDto>
{
    private IMapper _mapper;

    public BaseCreateRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TEntityDto Create(TEntityDto entityToCreate)
    {
        var dbEntity = _mapper.Map<TDbEntity>(entityToCreate);
        // TODO: Implement function
        return _mapper.Map<TEntityDto>(dbEntity);
    }
}