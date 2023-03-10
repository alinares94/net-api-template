namespace $safeprojectname$.Interfaces.Services.Base;

/// <summary>
/// Valida los DTO antes de insertar o actualizar
/// </summary>
/// <exception cref="ValidationException">En el caso de que no pase las validaciones</exception>
/// <typeparam name="TDto"></typeparam>
/// <typeparam name="TEntityFrameWork"></typeparam>
public interface IValidatedCrudService<TDto, TEntityFrameWork> : ICrudService<TDto, TEntityFrameWork>
    where TDto : DtoBase
{
}
