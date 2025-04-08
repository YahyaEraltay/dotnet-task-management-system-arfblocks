namespace Application.RequestHandlers.TodoTasks.Queries.Detail
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

			var task = await _dataAccessLayer.TaskDetail(requestPayload.Id);

			var mappedTask = mapper.MapToResponse(task);
			return ArfBlocksResults.Success(mappedTask);
		}
	}
}