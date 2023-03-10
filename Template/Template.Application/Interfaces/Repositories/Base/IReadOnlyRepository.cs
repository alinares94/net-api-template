using System.Linq.Expressions;

namespace $safeprojectname$.Interfaces.Repositories.Base;

/// <summary>
/// Repositorio de solo lectura
/// </summary>
/// <typeparam name="TEntityFrameWork">Entidad de Base de datos</typeparam>
public interface IReadOnlyRepository<TEntityFrameWork> : IBaseRepository
{
    /// <summary>
    /// Obtiene la PK de una entidad
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    object? GetKey(TEntityFrameWork entity);

    /// <summary>
    /// Obtiene todas las entidades
    /// </summary>
    /// <returns></returns>
    Task<IReadOnlyCollection<TEntityFrameWork>> GetAllAsync(bool disableTracking = true);

    /// <summary>
    /// Obtiene una entidad por su PK
    /// </summary>
    /// <returns></returns>
    Task<TEntityFrameWork> GetByIdAsync(bool disableTracking, params object[] ids);

    /// <summary>
    /// Obtiene una lista de entidades que cumple con una condición
    /// </summary>
    /// <param name="predicate">Condición</param>
    /// <param name="includes">Uniones</param>
    /// <returns></returns>
    Task<IReadOnlyList<TEntityFrameWork>> GetAsync(
        Expression<Func<TEntityFrameWork, bool>>? predicate = null, params Expression<Func<TEntityFrameWork, object>>[] includes);

    /// <summary>
    /// Obtiene una lista de entidades que cumple con una condición
    /// </summary>
    /// <param name="predicate">Condición</param>
    /// <param name="orderBy">Campo por el que ordenar</param>
    /// <param name="includes">Uniones</param>
    /// <param name="disableTracking">Deshabilitar la detección de cambios</param>
    /// <returns></returns>
    Task<IReadOnlyList<TEntityFrameWork>> GetAsync(
        Expression<Func<TEntityFrameWork, bool>>? predicate = null, Func<IQueryable<TEntityFrameWork>, IOrderedQueryable<TEntityFrameWork>>? orderBy = null,
        List<Expression<Func<TEntityFrameWork, object>>>? includes = null, bool disableTracking = true, int? take = null);
}
