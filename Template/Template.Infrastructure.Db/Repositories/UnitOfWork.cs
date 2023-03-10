using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Collections;

namespace Template.Infrastructure.Db.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly TemplateContext _dbContext;
    private readonly Hashtable _repositories = new();

    public UnitOfWork(TemplateContext dbContext) => _dbContext = dbContext;

    #region Repositories

    private IStatusRepository? _statusRepository;

    public IStatusRepository StatusRepository => _statusRepository ??= new StatusRepository(_dbContext);

    #endregion

    #region Methods

    private static void DetachLocal<T>(DbContext context, T entity, object entryId, PropertyInfo propertyInfo)
        where T : class
    {
        var local = context.Set<T>().Local.FirstOrDefault(entry => propertyInfo.GetValue(entry)?.Equals(entryId) ?? false);
        if (local is not null)
        {
            context.Entry(local).State = EntityState.Detached;
        }
        context.Entry(entity).State = EntityState.Modified;
    }

    public void DetachLocal<T>(T entity, object entryId, PropertyInfo propertyInfo)
        where T : class
    {
        DetachLocal(_dbContext, entity, entryId, propertyInfo);
    }

    public async Task<int> CompleteAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task<IDbTransaction?> BeginTransaction()
    {
        var transaction = await _dbContext.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted) as IInfrastructure<DbTransaction>;
        return transaction?.GetInfrastructure();
    }

    public IReadOnlyRepository<TEntityFramework> Repository<TEntityFramework>()
    {
        var entityType = typeof(TEntityFramework);
        if (!_repositories.ContainsKey(entityType.Name))
        {
            var temp = GetType().GetProperties();
            var property = temp.Where(x => x.PropertyType.IsAssignableTo(typeof(IReadOnlyRepository<TEntityFramework>))).First();
            var repositoryInstance = property.GetValue(this);
            _repositories.Add(entityType.Name, repositoryInstance);
        }

        return (IReadOnlyRepository<TEntityFramework>)_repositories[entityType.Name]!;
    }

    #endregion
}
