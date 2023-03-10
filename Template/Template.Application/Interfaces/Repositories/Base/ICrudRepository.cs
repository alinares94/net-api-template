namespace $safeprojectname$.Interfaces.Repositories.Base;

/// <summary>
/// Repositorio CRUD
/// </summary>
/// <typeparam name="TEntityFrameWork">Entidad de Base de datos</typeparam>
public interface ICrudRepository<TEntityFrameWork> : IReadOnlyRepository<TEntityFrameWork>
{
    /// <summary>
    /// Inserta una entidad sin guardar los cambios en el contexto
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Devuelve la nueva entidad</returns>
    void Insert(TEntityFrameWork entity);

    /// <summary>
    /// Actualiza una entidad sin guardar los cambios en el contexto
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>Devuelve la nueva entidad</returns>
    void Update(TEntityFrameWork entity);

    /// <summary>
    /// Elimina una entidad sin guardar los cambios en el contexto
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    void Delete(TEntityFrameWork entity);

    /// <summary>
    /// Elimina varias entidades sin guardar los cambios en el contexto
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    void Delete(IEnumerable<TEntityFrameWork> entities);
}
