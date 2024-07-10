namespace Application.RequestHandlers.Departments.Commands.Delete
{
	public class Verificator : IRequestVerificator
	{
		private readonly ApplicationDbContext _dbContext;
		private readonly CurrentClientService _clientService;

		public Verificator(ArfBlocksDependencyProvider dependencyProvider)
		{
			_dbContext = dependencyProvider.GetInstance<ApplicationDbContext>();
			_clientService = dependencyProvider.GetInstance<CurrentClientService>();
		}

		public async Task VerificateActor(IRequestModel payload, CancellationToken cancellationToken)
		{
			await Task.CompletedTask;

        }
		public async Task VerificateDomain(IRequestModel payload, CancellationToken cancellationToken)
		{
			await Task.CompletedTask;
		}
	}
}