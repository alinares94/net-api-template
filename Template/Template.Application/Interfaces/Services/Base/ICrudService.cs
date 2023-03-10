namespace $safeprojectname$.Interfaces.Services.Base;

public interface ICrudService<TEntityFrameWork> : IReadOnlyService<TEntityFrameWork>
{
    /// <summary>
    /// Inserta una entidad y retorna la nueva entidad
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<TEntityFrameWork> InsertAsync(TEntityFrameWork entity);

    /// <summary>
    /// Actualiza una entidad y retorna la nueva entidad
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<TEntityFrameWork> UpdateAsync(TEntityFrameWork entity);

    /// <summary>
    /// Elimina una entidad
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<bool> DeleteAsync(TEntityFrameWork entity);

    /// <summary>
    /// Elimina una entidad por Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteByIdAsync(params object[] pk);
}

public interface ICrudService<TDto, TEntityFrameWork> : IReadOnlyService<TDto, TEntityFrameWork>
    where TDto : DtoBase
{
    /// <summary>
    /// Inserta una entidad y retorna la PK
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<object?> InsertDtoAsync(TDto entity);

    /// <summary>
    /// Actualiza una entidad y retorna la PK
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<object?> UpdateDtoAsync(TDto entity);

    /// <summary>
    /// Elimina una entidad por id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> DeleteByIdAsync(params object[] pk);
}
