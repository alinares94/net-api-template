namespace $safeprojectname$.Fixtures;
public class StatusFixture : FixtureBase
{
    public StatusFixture()
    {
        StatusService = new StatusService(MockUnitOfWork.Object, Mapper);
    }

    public IStatusService StatusService { get; init; }
}
