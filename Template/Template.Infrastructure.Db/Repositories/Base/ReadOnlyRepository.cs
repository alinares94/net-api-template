using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace $safeprojectname$.Repositories.Base;
public class ReadOnlyRepository<TEntityFrameWork, TContext> : BaseRepository, IReadOnlyRepository<TEntityFrameWork>
    where TEntityFrameWork : class
    where TContext : DbContext
{
    private readonly TContext _context;
    protected DbSet<TEntityFrameWork> DbSet { get; }

    public ReadOnlyRepository(TContext context)
    {
        _context = context;
        DbSet = _context.Set<TEntityFrameWork>();
    }

    protected EntityEntry<TEntityFrameWork> Entry(TEntityFrameWork entity)
    {
        return _context.Entry(entity);
    }

    /// <inheritdoc/>
    public virtual object? GetKey(TEntityFrameWork entity)
    {
        if (entity == null)
            return null;

        var keyName = _context.Model.FindEntityType(typeof(TEntityFrameWork))?
            .FindPrimaryKey()?.Properties
            .Select(x => x.Name).FirstOrDefault();

        if (string.IsNullOrEmpty(keyName))
            return null;

        return entity.GetType().GetProperty(keyName)?.GetValue(entity);
    }

    /// <inheritdoc/>
    public virtual async Task<IReadOnlyCollection<TEntityFrameWork>> GetAllAsync(bool disableTracking = true)
    {
        if (disableTracking)
            DbSet.AsNoTracking();
        return await DbSet.ToListAsync();
    }

    /// <inheritdoc/>
    public virtual async Task<TEntityFrameWork> GetByIdAsync(bool disableTracking, params object[] ids)
    {
        if (disableTracking)
            DbSet.AsNoTracking();
        return (await DbSet.FindAsync(ids))!;
    }

    /// <inheritdoc/>
    public async Task<IReadOnlyList<TEntityFrameWork>> GetAsync(
        Expression<Func<TEntityFrameWork, bool>>? predicate = null, Func<IQueryable<TEntityFrameWork>, IOrderedQueryable<TEntityFrameWork>>? orderBy = null,
        List<Expression<Func<TEntityFrameWork, object>>>? includes = null, bool disableTracking = true, int? take = null)
    {
        IQueryable<TEntityFrameWork> query = DbSet;

        if (disableTracking)
            query = query.AsNoTracking();
        if (includes != null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        if (predicate != null)
            query = query.Where(predicate);
        if (orderBy != null)
            query = orderBy(query);
        if (take.GetValueOrDefault() > 0)
            query = query.Take(take!.Value);

        return await query.ToListAsync();
    }

    /// <inheritdoc/>
    public Task<IReadOnlyList<TEntityFrameWork>> GetAsync(Expression<Func<TEntityFrameWork, bool>>? predicate, params Expression<Func<TEntityFrameWork, object>>[] includes)
    {
        return GetAsync(predicate, includes: includes.ToList());
    }
}
