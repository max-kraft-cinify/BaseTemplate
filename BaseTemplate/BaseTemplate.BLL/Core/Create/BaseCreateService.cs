using AutoMapper;
using BaseTemplate.PAL.Core.Create;

namespace BaseTemplate.BLL.Core.Create;

public class BaseCreateService<TEntity, TEntityDto>: IBaseCreateService<TEntity>
{
    private readonly IBaseCreateRepository<TEntityDto> _baseCreateRepository;
    private readonly IMapper _mapper;

    public BaseCreateService(IBaseCreateRepository<TEntityDto> baseCreateRepository, IMapper mapper)
    {
        _baseCreateRepository = baseCreateRepository;
        _mapper = mapper;
    }

    public TEntity Create(TEntity entityToCreate)
    {
        var entityDtoToCreate = _mapper.Map<TEntityDto>(entityToCreate);
        var createdEntityDto = _baseCreateRepository.Create(entityDtoToCreate);
        return _mapper.Map<TEntity>(createdEntityDto);
    }
}