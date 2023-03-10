using AutoMapper;
using Microsoft.Extensions.Configuration;
using $ext_safeprojectname$.Application.Mapper;

namespace $safeprojectname$.Fixtures.Base;

/// <summary>
/// Fixture base con objetos comunes
/// </summary>
public class FixtureBase : IDisposable
{
    /// <summary>
    /// Constructor
    /// </summary>
    public FixtureBase()
    {
        Mapper = new MapperConfiguration(x => x.AddProfile<MapperProfile>()).CreateMapper();
        Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        MockUnitOfWork = Mocks.Database.MockUnitOfWork.GetUnitOfWork();
    }

    /// <summary>
    /// Configuración recogida de appsettings.json
    /// </summary>
    protected IConfiguration Configuration { get; init; }

    /// <summary>
    /// Automapper
    /// </summary>
    protected IMapper Mapper { get; init; }

    /// <summary>
    /// UnitOfWork con base de datos en memoria
    /// </summary>
    protected Mock<UnitOfWork> MockUnitOfWork { get; init; }


    /// <summary>
    /// Eliminación de recursos
    /// </summary>
    public virtual void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
