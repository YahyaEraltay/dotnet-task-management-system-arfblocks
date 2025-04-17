namespace Application.RequestHandlers.Departments.Queries.Detail;

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

		var department = await _dataAccessLayer.GetDepartmentById(requestPayload.Id);

		var response = mapper.MapToResponse(department);
		return ArfBlocksResults.Success(response);
	}
}