using System.Data;
using System.Reflection;

namespace $safeprojectname$.Interfaces.Repositories;
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Confirma los cambios pendientes
    /// </summary>
    /// <returns></returns>
    Task<int> CompleteAsync();

    /// <summary>
    /// Libera el changetracker de EF
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="entity"></param>
    /// <param name="entryId"></param>
    /// <param name="propertyInfo"></param>
    void DetachLocal<T>(T entity, object entryId, PropertyInfo propertyInfo) where T : class;

    /// <summary>
    /// Inicia una transacción y la devuelve
    /// </summary>
    /// <returns></returns>
    Task<IDbTransaction?> BeginTransaction();
    
    /// <summary>
    /// Obtiene el repositorio genérico correspondiente a tipo indicado
    /// </summary>
    /// <typeparam name="TEntityFramework"></typeparam>
    /// <returns></returns>
    IReadOnlyRepository<TEntityFramework> Repository<TEntityFramework>();

    IStatusRepository StatusRepository { get; }
}
