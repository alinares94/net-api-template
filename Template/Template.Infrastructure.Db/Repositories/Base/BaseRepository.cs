namespace $safeprojectname$.Repositories.Base;
public abstract class BaseRepository : IBaseRepository
{
    protected bool _disposed;
    public void Dispose()
    {
        if (_disposed)
            return;

        _disposed = true;
        GC.SuppressFinalize(this);
    }
}
