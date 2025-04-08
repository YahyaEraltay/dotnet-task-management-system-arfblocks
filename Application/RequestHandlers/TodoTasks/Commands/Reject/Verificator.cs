namespace Application.RequestHandlers.TodoTasks.Commands.Reject
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

		public async Task VerificateActor(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
		{
			var requestPayload = (RequestModel)payload;
			var currentUserId = _clientService.GetCurrentUserId();

			var task = await _dbContext.Tasks
											.FirstOrDefaultAsync(r => r.Id == requestPayload.Id);

			var currentUser = await _dbContext.Users
											.FirstOrDefaultAsync(u => u.Id == currentUserId);

			var verificationResult = DbVerificationService.CheckForReject(task, currentUser);
			if (verificationResult.HasError)
				throw new ArfBlocksVerificationException(verificationResult.ErrorCode);
		}

		public async Task VerificateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
		{
			await Task.CompletedTask;
		}
	}
}