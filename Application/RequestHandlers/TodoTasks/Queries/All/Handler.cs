namespace Application.RequestHandlers.TodoTasks.Queries.All
{
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

			(var todoTasks, var pageResponse) = await _dataAccessLayer.GetAllTodoTasks(requestPayload.Sorting, requestPayload.Filters, requestPayload.PageRequest);

			var response = mapper.MapToResponse(todoTasks);
			return ArfBlocksResults.Success(response, pageResponse);
		}
	}
}