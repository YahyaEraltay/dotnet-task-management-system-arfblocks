namespace Application.RequestHandlers.TodoTasks.Commands.Update
{
	public class Handler : IRequestHandler
	{
		private readonly DataAccess dataAccessLayer;
		private readonly CurrentUserService _currentUser;

		public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
		{
			dataAccessLayer = (DataAccess)dataAccess;
        _currentUser = dependencyProvider.GetInstance<CurrentUserService>();
		}

		public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
		{
			var mapper = new Mapper();
			var requestPayload = (RequestModel)payload;

			var task = await dataAccessLayer.GetById(requestPayload.Id);

			task = mapper.MapToEntity(requestPayload, task);

			await dataAccessLayer.Update(task);

			var response = mapper.MapToResponse(task);
			return ArfBlocksResults.Success(response);
		}
	}
}