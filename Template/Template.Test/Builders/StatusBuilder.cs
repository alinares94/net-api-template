namespace $safeprojectname$.Builders;
public class StatusBuilder : BuilderBase<StatusBuilder, StatusDto>
{
    public StatusBuilder WithTestProperty(string testProperty)
    {
        Entity.TestProperty = testProperty;
        return this;
    }
}
