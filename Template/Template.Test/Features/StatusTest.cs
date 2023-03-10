namespace $safeprojectname$.Features;
public class StatusTest : IClassFixture<StatusFixture>
{
    private readonly StatusFixture _fixture;

    public StatusTest(StatusFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName = "Status Test")]
    public async Task Test()
    {
        var result = await _fixture.StatusService.GetAsync();
        Assert.NotNull(result);
        Assert.True(result.Success);
    }
}
