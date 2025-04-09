namespace Application.RequestHandlers.TodoTasks.Commands.Complete
{
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
			var requestPayload = (RequestModel)payload;
			var currentUserId = _currentUser.GetCurrentUserId();

			var task = await _dbContext.Tasks
											.FirstOrDefaultAsync(r => r.Id == requestPayload.Id);

			var currentUser = await _dbContext.Users
											.FirstOrDefaultAsync(u => u.Id == currentUserId);

			var verificationResult = DbVerificationService.CheckForComplete(task, currentUser);
			if (verificationResult.HasError)
				throw new ArfBlocksVerificationException(verificationResult.ErrorCode);
		}

		public async Task VerificateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
		{
			await Task.CompletedTask;
		}
	}
}