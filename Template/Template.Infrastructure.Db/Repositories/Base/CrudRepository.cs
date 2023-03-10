using Microsoft.EntityFrameworkCore;

namespace $safeprojectname$.Repositories.Base;
public class CrudRepository<TEntityFrameWork, TContext> : ReadOnlyRepository<TEntityFrameWork, TContext>, ICrudRepository<TEntityFrameWork>
    where TEntityFrameWork : class
    where TContext : DbContext
{
    public CrudRepository(TContext context) : base(context)
    { }

    /// <inheritdoc/>
    public virtual void Insert(TEntityFrameWork entity)
    {
        if (entity == null)
            return;
        DbSet.Add(entity);
    }

    /// <inheritdoc/>
    public virtual void Update(TEntityFrameWork entity)
    {
        if (entity == null)
            return;
        DbSet.Attach(entity);
        Entry(entity).State = EntityState.Modified;
    }

    /// <inheritdoc/>
    public virtual void Delete(TEntityFrameWork entity)
    {
        if (entity == null)
            return;
        DbSet.Remove(entity);
    }

    /// <inheritdoc/>
    public virtual void Delete(IEnumerable<TEntityFrameWork> entities)
    {
        if (entities == null || !entities.Any())
            return;
        DbSet.RemoveRange(entities);
    }
}
