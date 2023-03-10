namespace $safeprojectname$.Interfaces.Services;
public interface IStatusService : IBaseService
{
    /// <summary>
    /// Obtiene el estado de la aplicación
    /// </summary>
    /// <returns></returns>
    Task<StatusDto> GetAsync();
}
