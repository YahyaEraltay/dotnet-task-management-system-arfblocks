namespace Application.RequestHandlers.TodoTasks.Commands.Reject
{
	[InternalHandler]
	public class Handler : IRequestHandler
	{
		private readonly DataAccess dataAccessLayer;

		public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
		{
			dataAccessLayer = (DataAccess)dataAccess;
		}

		public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, CancellationToken cancellationToken)
		{
			var mapper = new Mapper();
			var requestPayload = (RequestModel)payload;

			var task = await dataAccessLayer.GetById(requestPayload.Id);

			await dataAccessLayer.Update(task);

			var mappedResponseModel = mapper.MapToResponse(task);
			return ArfBlocksResults.Success(mappedResponseModel);
		}
	}
}