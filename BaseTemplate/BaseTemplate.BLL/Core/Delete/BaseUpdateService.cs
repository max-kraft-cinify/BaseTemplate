using AutoMapper;
using BaseTemplate.PAL.Core.Delete;

namespace BaseTemplate.BLL.Core.Delete;

public class BaseDeleteService<TEntity, TEntityDto>: IBaseDeleteService<TEntity>
{
    private readonly IBaseDeleteRepository<TEntityDto> _baseDeleteRepository;
    private readonly IMapper _mapper;

    public BaseDeleteService(IBaseDeleteRepository<TEntityDto> baseDeleteRepository, IMapper mapper)
    {
        _baseDeleteRepository = baseDeleteRepository;
        _mapper = mapper;
    }

    public bool Delete(TEntity entityToDelete)
    {
        var entityDtoToDelete = _mapper.Map<TEntityDto>(entityToDelete);
        return _baseDeleteRepository.Delete(entityDtoToDelete);
    }
}