namespace Application.RequestHandlers.TodoTasks.Commands.Update
{
	public class Validator : IRequestValidator
	{
		private readonly DbValidationService _dbValidator;
		public Validator(ArfBlocksDependencyProvider dependencyProvider)
		{
			_dbValidator = dependencyProvider.GetInstance<DbValidationService>();
		}

		public void ValidateRequestModel(IRequestModel payload, CancellationToken cancellationToken)
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

		public async Task ValidateDomain(IRequestModel payload, CancellationToken cancellationToken)
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
				.NotNull().WithMessage("TASK_ID_NOT_VALID")
				.NotEqual(Guid.Empty).WithMessage("TASK_ID_NOT_VALID");

			RuleFor(x => x.Title)
				.NotEmpty().WithMessage("TITLE_IS_EMPTY");

			RuleFor(x => x.AssignedDepartmentId)
				.NotNull().WithMessage("ASSIGNED_DEPARTMENT_ID_NOT_VALID")
				.NotEqual(Guid.Empty).WithMessage("ASSIGNED_DEPARTMENT_ID_NOT_VALID");
		}
	}
}