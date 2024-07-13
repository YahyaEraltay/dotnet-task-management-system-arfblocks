namespace Application.RequestHandlers.TodoTasks.Commands.Update
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
            var requestPayload = (RequestModel)payload;

            var task = await dataAccessLayer.GetById(requestPayload.Id);

            task = mapper.MapToEntity(requestPayload, task);

            await dataAccessLayer.Update(task);

            var response = mapper.MapToResponse(task);
            return ArfBlocksResults.Success(response);
		}
	}
}