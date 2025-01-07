using AutoMapper;
using BaseTemplate.BLL.Core.Delete;

namespace BaseTemplate.DAL.Core.Delete;

public class BaseDeleteRepository<TEntityDto, TDbEntity> : IBaseDeleteRepository<TEntityDto>
{
    private IMapper _mapper;

    public BaseDeleteRepository(IMapper mapper)
    {
        _mapper = mapper;
    }

    public bool Delete(TEntityDto entityToDelete)
    {
        var dbEntity = _mapper.Map<TDbEntity>(entityToDelete);
        // TODO: Implement function
        return dbEntity != null;
    }
}