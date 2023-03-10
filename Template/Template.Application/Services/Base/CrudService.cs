namespace $safeprojectname$.Services.Base;

/// <inheritdoc/>
public abstract class CrudService<TEntityFrameWork> : ReadOnlyService<TEntityFrameWork>, ICrudService<TEntityFrameWork>
{
    public CrudService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteAsync(TEntityFrameWork entity)
    {
        (_unitOfWork.Repository<TEntityFrameWork>() as ICrudRepository<TEntityFrameWork>)!.Delete(entity);
        var result = await _unitOfWork.CompleteAsync();
        return result > 0;
    }

    /// <inheritdoc/>
    public async Task<bool> DeleteByIdAsync(params object[] pk)
    {
        var ef = await GetByIdAsync(pk);
        (_unitOfWork.Repository<TEntityFrameWork>() as ICrudRepository<TEntityFrameWork>)!.Delete(ef);
        var result = await _unitOfWork.CompleteAsync();
        return result > 0;
    }

    /// <inheritdoc/>
    public async Task<TEntityFrameWork> InsertAsync(TEntityFrameWork entity)
    {
        (_unitOfWork.Repository<TEntityFrameWork>() as ICrudRepository<TEntityFrameWork>)!.Insert(entity);
        await _unitOfWork.CompleteAsync();
        return entity;
    }

    /// <inheritdoc/>
    public async Task<TEntityFrameWork> UpdateAsync(TEntityFrameWork entity)
    {
        (_unitOfWork.Repository<TEntityFrameWork>() as ICrudRepository<TEntityFrameWork>)!.Update(entity);
        await _unitOfWork.CompleteAsync();
        return entity;
    }
}

public abstract class CrudService<TDto, TEntityFrameWork> : ReadOnlyService<TDto, TEntityFrameWork>, ICrudService<TDto, TEntityFrameWork>
    where TDto : DtoBase
{

    public CrudService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
    }

    /// <inheritdoc/>
    public virtual async Task<object?> InsertDtoAsync(TDto entity)
    {
        var ef = Mapper.Map<TEntityFrameWork>(entity);
        var repository = (_unitOfWork.Repository<TEntityFrameWork>() as ICrudRepository<TEntityFrameWork>)!;
        repository.Insert(ef);
        await _unitOfWork.CompleteAsync();
        return repository.GetKey(ef);
    }

    /// <inheritdoc/>
    public virtual async Task<object?> UpdateDtoAsync(TDto entity)
    {
        var ef = Mapper.Map<TEntityFrameWork>(entity);
        var repository = (_unitOfWork.Repository<TEntityFrameWork>() as ICrudRepository<TEntityFrameWork>)!;
        repository.Update(ef);
        await _unitOfWork.CompleteAsync();
        return repository.GetKey(ef);
    }

    /// <inheritdoc/>
    public virtual async Task<bool> DeleteByIdAsync(params object[] pk)
    {
        var ef = await GetByIdAsync(pk);
        (_unitOfWork.Repository<TEntityFrameWork>() as ICrudRepository<TEntityFrameWork>)!.Delete(ef);
        var result = await _unitOfWork.CompleteAsync();
        return result > 0;
    }
}
