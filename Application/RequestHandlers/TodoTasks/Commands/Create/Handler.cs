namespace Application.RequestHandlers.TodoTasks.Commands.Create
{
	public class Handler : IRequestHandler
	{
		private readonly DataAccess dataAccessLayer;
		private readonly CurrentUserService _currentUser;

		public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
		{
			dataAccessLayer = (DataAccess)dataAccess;
			_currentUser = dependencyProvider.GetInstance<CurrentUserService>();
		}

		public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
		{
			var mapper = new Mapper();
			var currentUserId = _currentUser.GetCurrentUserId();
			var requestPayload = (RequestModel)payload;

			var task = mapper.MapToNewEntity(requestPayload, currentUserId);

			await dataAccessLayer.Add(task);

			var mappedResponseModel = mapper.MapToNewResponseModel(task);
			return ArfBlocksResults.Success(mappedResponseModel);
		}
	}
}