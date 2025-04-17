namespace Application.RequestHandlers.TodoTasks.Commands.Update;

public class Validator : IRequestValidator
{
	private readonly DbValidationService _dbValidator;
	public Validator(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbValidator = dependencyProvider.GetInstance<DbValidationService>();
	}

	public void ValidateRequestModel(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		// Get Request Payload
		var requestModel = (RequestModel)payload;

		// Request Model Validation
		var validationResult = new RequestModel_Validator().Validate(requestModel);
		if (!validationResult.IsValid)
		{
			var errors = validationResult.ToString("~");
			throw new ArfBlocksValidationException(errors);
		}
	}

	public async Task ValidateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		// Get Request Payload
		var requestModel = (RequestModel)payload;

		// DB Validations
		await _dbValidator.ValidateTodoTaskExist(requestModel.Id);
		await _dbValidator.ValidateDepartmentExist(requestModel.AssignedDepartmentId);
	}
}

public class RequestModel_Validator : AbstractValidator<RequestModel>
{
	public RequestModel_Validator()
	{
		RuleFor(x => x.Id)
			.NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.IdNotValid))
			.NotEqual(Guid.Empty).WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.IdNotValid));

		RuleFor(x => x.Title)
				.NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.TodoTaskErrors.TitleNotValid))
				.NotEmpty().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.TodoTaskErrors.TitleNotValid));

		RuleFor(x => x.Description)
			.NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.TodoTaskErrors.DescriptionNotValid))
			.NotEmpty().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.TodoTaskErrors.DescriptionNotValid));

		RuleFor(x => x.AssignedDepartmentId)
			.NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.DepartmentErrors.AssignedDepartmentIdNotValid))
			.NotEqual(Guid.Empty).WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.DepartmentErrors.AssignedDepartmentIdNotValid));
	}
}