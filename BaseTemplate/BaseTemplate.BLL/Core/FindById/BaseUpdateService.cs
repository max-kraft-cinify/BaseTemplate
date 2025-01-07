using AutoMapper;
using BaseTemplate.PAL.Core.FindById;

namespace BaseTemplate.BLL.Core.FindById;

public class BaseFindByIdService<TEntity, TEntityDto>: IBaseFindByIdService<TEntity>
{
    private readonly IBaseFindByIdRepository<TEntityDto> _baseFindByIdRepository;
    private readonly IMapper _mapper;

    public BaseFindByIdService(IBaseFindByIdRepository<TEntityDto> baseFindByIdRepository, IMapper mapper)
    {
        _baseFindByIdRepository = baseFindByIdRepository;
        _mapper = mapper;
    }

    public TEntity FindById(int id)
    {
        var entityDto = _baseFindByIdRepository.FindById(id);
        return _mapper.Map<TEntity>(entityDto);
    }
}