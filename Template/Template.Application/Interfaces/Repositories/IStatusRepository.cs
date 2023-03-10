namespace $safeprojectname$.Interfaces.Repositories;
public interface IStatusRepository : IReadOnlyRepository<Status>
{
    Task<Status> GetAsync();
}
