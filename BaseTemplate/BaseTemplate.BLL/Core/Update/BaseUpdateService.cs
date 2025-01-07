using AutoMapper;
using BaseTemplate.PAL.Core.Update;

namespace BaseTemplate.BLL.Core.Update;

public class BaseUpdateService<TEntity, TEntityDto>: IBaseUpdateService<TEntity>
{
    private readonly IBaseUpdateRepository<TEntityDto> _baseUpdateRepository;
    private readonly IMapper _mapper;

    public BaseUpdateService(IBaseUpdateRepository<TEntityDto> baseUpdateRepository, IMapper mapper)
    {
        _baseUpdateRepository = baseUpdateRepository;
        _mapper = mapper;
    }

    public TEntity Update(TEntity entityToUpdate)
    {
        var entityDtoToUpdate = _mapper.Map<TEntityDto>(entityToUpdate);
        var updatedEntityDto = _baseUpdateRepository.Update(entityDtoToUpdate);
        return _mapper.Map<TEntity>(updatedEntityDto);
    }
}