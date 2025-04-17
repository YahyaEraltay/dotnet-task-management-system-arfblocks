namespace Application.RequestHandlers.Users.Queries.Detail;

public class Handler : IRequestHandler
{
	private readonly DataAccess _dataAccessLayer;
	private readonly DbValidationService _dbValidationService;
	public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
	{
		_dataAccessLayer = (DataAccess)dataAccess;


		_dbValidationService = dependencyProvider.GetInstance<DbValidationService>();
	}

	public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var mapper = new Mapper();
		var requestPayload = (RequestModel)payload;

		var user = await _dataAccessLayer.GetUserById(requestPayload.Id);

		var response = mapper.MapToResponse(user);
		return ArfBlocksResults.Success(response);
	}
}