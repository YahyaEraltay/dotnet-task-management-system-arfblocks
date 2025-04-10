namespace Application.RequestHandlers.Departments.Queries.Detail
{
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

			var department = await _dataAccessLayer.GetById(requestPayload.Id);

			var mappedDepartment = mapper.MapToResponse(department);
			return ArfBlocksResults.Success(mappedDepartment);
		}
	}
}