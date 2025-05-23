namespace Application.RequestHandlers.Users.Commands.Update;

public class Validator : IRequestValidator
{
    private readonly DbValidationService _dbValidator;

    public Validator(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dbValidator = dependencyProvider.GetInstance<DbValidationService>();
    }

    public async Task ValidateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
    {
        var requestPayload = (RequestModel)payload;

        await _dbValidator.ValidateUserExistById(requestPayload.Id);
        await _dbValidator.ValidateDepartmentExist(requestPayload.DepartmentId);
    }

    public void ValidateRequestModel(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
    {
        var requestModel = (RequestModel)payload;

        var validationResult = new RequestModel_Validator().Validate(requestModel);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.ToString("~");
            throw new ArfBlocksValidationException(errors);
        }
    }
}

public class RequestModel_Validator : AbstractValidator<RequestModel>
{
    public RequestModel_Validator()
    {
        RuleFor(x => x.Id)
                    .NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.IdNotValid))
                    .NotEqual(Guid.Empty).WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.IdNotValid));

        RuleFor(x => x.FirstName)
                    .NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.FirstNameNotValid))
                    .NotEmpty().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.FirstNameNotValid));

        RuleFor(x => x.LastName)
                    .NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.LastNameNotValid))
                    .NotEmpty().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.LastNameNotValid));

        RuleFor(x => x.Email)
                    .NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.EmailNotValid))
                    .NotEmpty().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.EmailNotValid));

        RuleFor(x => x.DepartmentId)
                    .NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.DepartmentErrors.DepartmentIdNotValid))
                    .NotEqual(Guid.Empty).WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.DepartmentErrors.DepartmentIdNotValid));
    }
}