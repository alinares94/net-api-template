namespace $safeprojectname$.Repositories;
public class StatusRepository : ReadOnlyRepository<Status, TemplateContext>, IStatusRepository
{
    public StatusRepository(TemplateContext context) : base(context)
    {
    }

    public Task<Status> GetAsync()
    {
        // En este punto deben ir las consultas a bbdd
        return Task.FromResult(new Status { Success = true });
    }
}
