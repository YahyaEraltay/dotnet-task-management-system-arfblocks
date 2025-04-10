namespace Application.RequestHandlers.TodoTasks.Queries.MyTasks
{
	public class Handler : IRequestHandler
	{
		private readonly DataAccess _dataAccessLayer;
		private readonly CurrentUserService _currentUser;
		public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
		{
			_dataAccessLayer = (DataAccess)dataAccess;


			_currentUser = dependencyProvider.GetInstance<CurrentUserService>();
		}

		public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
		{
			var mapper = new Mapper();
			var requestPayload = (RequestModel)payload;
			var currentUserId = _currentUser.GetCurrentUserId();

			(var pendingTodoTasks, var pageResponse) = await _dataAccessLayer.GetAllPendingTasksByUserId(requestPayload.Sorting, requestPayload.Filters, requestPayload.PageRequest, currentUserId);

			var response = mapper.MapToResponse(pendingTodoTasks);
			return ArfBlocksResults.Success(response, pageResponse);
		}
	}
}