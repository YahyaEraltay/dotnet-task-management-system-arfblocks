namespace Application.RequestHandlers.TodoTasks.Commands.Create
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
			var requestModel = (RequestModel)payload;

			var validationResult = new RequestModel_Validator().Validate(requestModel);
			if (!validationResult.IsValid)
			{
				var errors = validationResult.ToString("~");
				throw new ArfBlocksValidationException(errors);
			}
		}

		public async Task ValidateDomain(IRequestModel payload, CancellationToken cancellationToken)
		{
			var requestModel = (RequestModel)payload;

			await _dbValidator.ValidateDepartmentExist(requestModel.AssignedDepartmentId);
		}
	}
//TODO:Erro mesaj
    public class RequestModel_Validator : AbstractValidator<RequestModel>
	{
		public RequestModel_Validator()
		{
			RuleFor(x => x.Title)
				.NotEmpty().WithMessage("COMPANY_NAME_IS_EMPTY");

			RuleFor(x => x.AssignedDepartmentId)
				.NotNull().WithMessage("ASSIGNED_DEPARTMENT_ID_NOT_VALID")
				.NotEqual(Guid.Empty).WithMessage("ASSIGNED_DEPARTMENT_ID_NOT_VALID");
		}
	}
}