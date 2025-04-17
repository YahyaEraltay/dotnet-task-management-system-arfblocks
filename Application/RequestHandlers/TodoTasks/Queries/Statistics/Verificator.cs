namespace Application.RequestHandlers.TodoTasks.Queries.Statistics;

public class Verificator : IRequestVerificator
{
	private readonly ApplicationDbContext _dbContext;
	private readonly CurrentUserService _currentUser;

	public Verificator(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbContext = dependencyProvider.GetInstance<ApplicationDbContext>();
		_currentUser = dependencyProvider.GetInstance<CurrentUserService>();
	}

	public async Task VerificateActor(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		await Task.CompletedTask;

	}
	public async Task VerificateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		await Task.CompletedTask;
	}
}