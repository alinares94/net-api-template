namespace $safeprojectname$.Validators;
public class StatusValidator : AbstractValidator<Status>
{
    public StatusValidator()
    {
        RuleFor(x => x.Success).NotEmpty();   
    }
}
