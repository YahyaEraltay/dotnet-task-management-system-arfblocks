namespace Application.RequestHandlers.TodoTasks.Queries.MyTasks
{
	public class Handler : IRequestHandler
	{
		private readonly DataAccess _dataAccessLayer;
		private readonly CurrentClientService _clientService;
		private readonly DbValidationService _dbValidationService;
		public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
		{
			_dataAccessLayer = (DataAccess)dataAccess;
			_clientService = dependencyProvider.GetInstance<CurrentClientService>();
			_dbValidationService = dependencyProvider.GetInstance<DbValidationService>();
		}

		public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, CancellationToken cancellationToken)
		{
            var mapper = new Mapper();
			var currentUserId = _clientService.GetCurrentUserId();

			var myTasks = await _dataAccessLayer.GetPendingTasks(currentUserId);

			var mappedTasks = mapper.MapToResponse(myTasks);
			return ArfBlocksResults.Success(mappedTasks);
		}
	}
}