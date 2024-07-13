namespace Application.RequestHandlers.TodoTasks.Commands.Delete
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
			var requestPayload = (RequestModel)payload;

			var validationResult = new RequestModel_Validator().Validate(requestPayload);
			if (!validationResult.IsValid)
			{
				var errors = validationResult.ToString("~");
				throw new ArfBlocksValidationException(errors);
			}
		}

		public async Task ValidateDomain(IRequestModel payload, CancellationToken cancellationToken)
		{
			var requestPayload = (RequestModel)payload;

			await _dbValidator.ValidateTodoTaskExist(requestPayload.Id);
		}
	}

    public class RequestModel_Validator : AbstractValidator<RequestModel>
	{
		public RequestModel_Validator()
		{
			RuleFor(x => x.Id)
				.NotNull().WithMessage("TASK_ID_NOT_VALID")
				.NotEqual(Guid.Empty).WithMessage("TASK_ID_NOT_VALID");

		}
	}
}