namespace Application.RequestHandlers.Users.Commands.Login
{
	[AllowAnonymousHandler]
	public class Handler : IRequestHandler
	{
		private readonly DataAccess dataAccessLayer;
		private readonly CurrentClientService _clientService;
		private readonly IJwtService _jwtService;

		public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
		{
			dataAccessLayer = (DataAccess)dataAccess;
			_clientService = dependencyProvider.GetInstance<CurrentClientService>();
			_jwtService = dependencyProvider.GetInstance<IJwtService>();
		}

		public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
		{
			var mapper = new Mapper();
			var requestPayload = (RequestModel)payload;

			var user = await dataAccessLayer.GetUserByEmail(requestPayload.Email);

			var jwtToken = _jwtService.GenerateJwt(user);

			var mappedResponseModel = mapper.MapToResponseModel(user, jwtToken);
			return ArfBlocksResults.Success(mappedResponseModel);
		}
	}
}