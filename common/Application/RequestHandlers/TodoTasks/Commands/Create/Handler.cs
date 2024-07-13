namespace Application.RequestHandlers.TodoTasks.Commands.Create
{
	public class Handler : IRequestHandler
	{
		private readonly DataAccess dataAccessLayer;
		private readonly CurrentClientService _clientService;

		public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
		{
			dataAccessLayer = (DataAccess)dataAccess;
			_clientService = dependencyProvider.GetInstance<CurrentClientService>();
		}

		public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, CancellationToken cancellationToken)
		{
			var mapper = new Mapper();
			var currentClientId = _clientService.GetCurrentUserId();
			var requestPayload = (RequestModel)payload;

			var task = mapper.MapToNewEntity(requestPayload, currentClientId);

			await dataAccessLayer.Add(task);

			var mappedResponseModel = mapper.MapToNewResponseModel(task);
			return ArfBlocksResults.Success(mappedResponseModel);
		}
	}
}