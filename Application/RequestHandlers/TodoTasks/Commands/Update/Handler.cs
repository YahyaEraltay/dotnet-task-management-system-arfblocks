namespace Application.RequestHandlers.TodoTasks.Commands.Update;

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

		var task = await _dataAccessLayer.GetTaskById(requestPayload.Id);

		task = mapper.MapToEntity(requestPayload, task);

		await _dataAccessLayer.UpdateTask(task);

		var response = mapper.MapToResponse(task);
		return ArfBlocksResults.Success(response);
	}
}