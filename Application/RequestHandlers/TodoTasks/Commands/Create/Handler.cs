namespace Application.RequestHandlers.TodoTasks.Commands.Create;

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
		var currentUserId = _currentUser.GetCurrentUserId();
		var requestPayload = (RequestModel)payload;

		var task = mapper.MapToNewEntity(requestPayload, currentUserId);

		await _dataAccessLayer.Add(task);

		var response = mapper.MapToResponse(task);
		return ArfBlocksResults.Success(response);
	}
}