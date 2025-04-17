namespace Application.RequestHandlers.TodoTasks.Commands.Complete;

public class Handler : IRequestHandler
{
	private readonly DataAccess _dataAccessLayer;


	public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
	{
		_dataAccessLayer = (DataAccess)dataAccess;

	}

	public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var mapper = new Mapper();
		var requestPayload = (RequestModel)payload;

		var task = await _dataAccessLayer.GetTaskById(requestPayload.Id);

		mapper.MapToEntity(task);

		await _dataAccessLayer.UpdateTask(task);

		var response = mapper.MapToResponse(task);
		return ArfBlocksResults.Success(response);
	}
}