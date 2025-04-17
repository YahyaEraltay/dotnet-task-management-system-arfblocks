namespace Application.RequestHandlers.TodoTasks.Queries.Statistics;

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

		var currentUser = _currentUser.GetCurrentUser();

		var myCreationsCount = await _dataAccessLayer.GetMyCreationsCountById(currentUser.Id);
		var waitingForMyApprovalsCount = await _dataAccessLayer.GetWaitingForMyApprovalsCountById(currentUser.DepartmentId);

		var response = mapper.MapToResponse(waitingForMyApprovalsCount, myCreationsCount);
		return ArfBlocksResults.Success(response);
	}
}