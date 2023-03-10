namespace $safeprojectname$.Interfaces.Services.Base;

public interface IReadOnlyService<TEntityFrameWork> : IBaseService
{
    /// <summary>
    /// Obtiene todos los elementos
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyCollection<TEntityFrameWork>> GetAllAsync();

    /// <summary>
    /// Obtiene un elemento por su PK
    /// </summary>
    /// <param name="pk"></param>
    /// <returns></returns>
    Task<TEntityFrameWork> GetByIdAsync(params object[] pk);
}

public interface IReadOnlyService<TDto, TEntityFrameWork> : IReadOnlyService<TEntityFrameWork>
    where TDto : DtoBase
{
    /// <summary>
    /// Obtiene todos los elementos
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyCollection<TDto>> GetAllDtoAsync();

    /// <summary>
    /// Obtiene un elemento por su PK
    /// </summary>
    /// <param name="pk"></param>
    /// <returns></returns>
    Task<TDto> GetDtoByIdAsync(params object[] pk);
}
