namespace Application.RequestHandlers.TodoTasks.Queries.Pendings
{
	public class Handler : IRequestHandler
	{
		private readonly DataAccess _dataAccessLayer;
		private readonly CurrentUserService _currentUser;
		private readonly DbValidationService _dbValidationService;
		public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
		{
			_dataAccessLayer = (DataAccess)dataAccess;
			_currentUser = dependencyProvider.GetInstance<CurrentUserService>();
			_dbValidationService = dependencyProvider.GetInstance<DbValidationService>();
		}

		public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
		{
			var mapper = new Mapper();
			var currentUserDepartmentId = _currentUser.GetCurrentUserDepartmentId();

			var pendingTasks = await _dataAccessLayer.GetPendingTasks(currentUserDepartmentId);

			var mappedTasks = mapper.MapToResponse(pendingTasks);
			return ArfBlocksResults.Success(mappedTasks);
		}
	}
}