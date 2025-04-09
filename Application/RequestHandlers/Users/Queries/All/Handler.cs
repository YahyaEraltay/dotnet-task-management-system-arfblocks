namespace Application.RequestHandlers.Users.Queries.All
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

			(var users, var pageResponse) = await _dataAccessLayer.GetAllUsers(requestPayload.Sorting, requestPayload.Filters, requestPayload.PageRequest);

			var response = mapper.MapToResponse(users);
			return ArfBlocksResults.Success(response, pageResponse);
		}
	}
}