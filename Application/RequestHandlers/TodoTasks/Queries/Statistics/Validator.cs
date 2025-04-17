namespace Application.RequestHandlers.TodoTasks.Queries.Statistics;

public class Validator : IRequestValidator
{
	private readonly DbValidationService _dbValidator;

	public Validator(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbValidator = dependencyProvider.GetInstance<DbValidationService>();
	}

	public async Task ValidateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		await Task.CompletedTask;
	}
	public void ValidateRequestModel(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
	}
}