namespace $safeprojectname$.Services.Base;

/// <inheritdoc/>
public abstract class ReadOnlyService<TEntityFrameWork> : BaseService, IReadOnlyService<TEntityFrameWork>
{
    protected readonly IUnitOfWork _unitOfWork;

    public ReadOnlyService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc/>
    public virtual async Task<IReadOnlyCollection<TEntityFrameWork>> GetAllAsync()
    {
        return await _unitOfWork.Repository<TEntityFrameWork>().GetAllAsync();
    }

    /// <inheritdoc/>
    public virtual async Task<TEntityFrameWork> GetByIdAsync(params object[] pk)
    {
        return await _unitOfWork.Repository<TEntityFrameWork>().GetByIdAsync(true, pk);
    }
}

public abstract class ReadOnlyService<TDto, TEntityFrameWork> : ReadOnlyService<TEntityFrameWork>, IReadOnlyService<TDto, TEntityFrameWork>
    where TDto : DtoBase
{

    public ReadOnlyService(IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
    {
    }

    /// <inheritdoc/>
    public virtual async Task<IReadOnlyCollection<TDto>> GetAllDtoAsync()
    {
        var entities = await _unitOfWork.Repository<TEntityFrameWork>().GetAllAsync();
        return Mapper.Map<IReadOnlyCollection<TDto>>(entities);
    }

    /// <inheritdoc/>
    public virtual async Task<TDto> GetDtoByIdAsync(params object[] pk)
    {
        var entity = await _unitOfWork.Repository<TEntityFrameWork>().GetByIdAsync(true, pk);
        return Mapper.Map<TDto>(entity);
    }
}
