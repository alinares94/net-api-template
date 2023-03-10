namespace $safeprojectname$.Services.Base;
public class BaseService : IBaseService
{
    public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    /// <summary>
    /// UnitOfWork. Contenedor de los repositorios y encargado de confirmar cambios en BBDD
    /// </summary>
    protected IUnitOfWork UnitOfWork { get; init; }

    /// <summary>
    /// Automapper
    /// </summary>
    protected IMapper Mapper { get; init; }
}
