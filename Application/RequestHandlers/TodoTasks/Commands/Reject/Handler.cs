namespace Application.RequestHandlers.TodoTasks.Commands.Reject
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

			var task = await _dataAccessLayer
.GetById(requestPayload.Id);

			task.Status = TodoTaskStatus.Rejected;
			await _dataAccessLayer
.Update(task);

			var mappedResponseModel = mapper.MapToResponse(task);
			return ArfBlocksResults.Success(mappedResponseModel);
		}
	}
}