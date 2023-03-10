using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace $safeprojectname$.Mocks.Database;

/// <summary>
/// Mock de UnitOfWork que simula una BBDD
/// </summary>
public static class MockUnitOfWork
{
    /// <summary>
    /// Devuelve el Mock del UnitOfWork
    /// </summary>
    public static Mock<UnitOfWork> GetUnitOfWork()
    {
        var options = new DbContextOptionsBuilder<TemplateContext>()
            .UseInMemoryDatabase(databaseName: $"Context-{Guid.NewGuid()}")
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
        .Options;
        return new Mock<UnitOfWork>(GetInMemoryDbContext(options));
    }

    private static TemplateContext GetInMemoryDbContext(DbContextOptions<TemplateContext> options)
    {
        var dbContext = new TemplateContext(options);
        dbContext.Database.EnsureDeleted();
        return dbContext.FillDbContext();
    }

    /// <summary>
    /// Encargado de llenar la base de datos. Para realizarlo de manera ordenada se debe crear un metodo de extension por cada tabla
    /// </summary>
    /// <param name="dbContext"></param>
    /// <returns></returns>
    private static TemplateContext FillDbContext(this TemplateContext dbContext)
    {
        return dbContext;
    }
}
