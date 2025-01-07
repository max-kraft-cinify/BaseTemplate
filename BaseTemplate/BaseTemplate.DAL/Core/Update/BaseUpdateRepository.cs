using AutoMapper;
using BaseTemplate.BLL.Core.Update;

namespace BaseTemplate.DAL.Core.Update;

public class BaseUpdateRepository<TEntityDto, TDbEntity> : IBaseUpdateRepository<TEntityDto>
{
    private IMapper _mapper;

    public BaseUpdateRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TEntityDto Update(TEntityDto entityToUpdate)
    {
        var dbEntity = _mapper.Map<TDbEntity>(entityToUpdate);
        // TODO: Implement function
        return _mapper.Map<TEntityDto>(dbEntity);
    }
}