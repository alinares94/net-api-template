namespace $safeprojectname$.Services;
public class StatusService : BaseService, IStatusService
{
    public StatusService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    /// <inheritdoc/>
    public async Task<StatusDto> GetAsync()
    {
        var ef = await UnitOfWork.StatusRepository.GetAsync();
        return Mapper.Map<StatusDto>(ef);
    }
}
