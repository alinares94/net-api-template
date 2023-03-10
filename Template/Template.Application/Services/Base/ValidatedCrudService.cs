namespace $safeprojectname$.Services.Base;

/// <inheritdoc/>
public abstract class ValidatedCrudService<TDto, TEntityFrameWork> : CrudService<TDto, TEntityFrameWork>, IValidatedCrudService<TDto, TEntityFrameWork>
    where TDto : DtoBase
{
    protected IValidator<TDto> Validator { get; init; }
    protected ValidatedCrudService(IValidator<TDto> validator, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
    {
        Validator =  validator;
    }

    /// <inheritdoc/>
    public override async Task<object?> InsertDtoAsync(TDto entity)
    {
        var validateResult = Validator.Validate(entity);
        if (validateResult.IsValid)
            return await base.InsertDtoAsync(entity);

        throw new Exceptions.ValidationException(validateResult.Errors);
    }

    /// <inheritdoc/>
    public override async Task<object?> UpdateDtoAsync(TDto entity)
    {
        var validateResult = Validator.Validate(entity);
        if (validateResult.IsValid)
            return await base.UpdateDtoAsync(entity);

        throw new Exceptions.ValidationException(validateResult.Errors);
    }
}
