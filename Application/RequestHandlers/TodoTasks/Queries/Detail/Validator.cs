namespace Application.RequestHandlers.TodoTasks.Queries.Detail
{
	public class Validator : IRequestValidator
	{
		private readonly DbValidationService _dbValidator;
		public Validator(ArfBlocksDependencyProvider dependencyProvider)
		{
			_dbValidator = dependencyProvider.GetInstance<DbValidationService>();
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

		public async Task ValidateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
		{
			var requestModel = (RequestModel)payload;

			await _dbValidator.ValidateTodoTaskExist(requestModel.Id);
		}
	}

	public class RequestModel_Validator : AbstractValidator<RequestModel>
	{
		public RequestModel_Validator()
		{
			RuleFor(x => x.Id)
				.NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.IdNotValid))
				.NotEqual(Guid.Empty).WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.CommonErrors.IdNotValid));
		}
	}
}