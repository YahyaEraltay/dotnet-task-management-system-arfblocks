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

		public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, CancellationToken cancellationToken)
		{
			var mapper = new Mapper();
			var requestPayload = (RequestModel)payload;

			// Get User from DB
			var user = await dataAccessLayer.GetUserByEmail(requestPayload.Email);

			// Build JWT Token
			var jwtToken = _jwtService.GenerateJwt(user);

			// Create Activity Log
			//var currentUserDisplayName = _clientService.GetCurrentUserDisplayName();
            //TODO: ActivityLogService oluştur ve ekle


			// Map to Response Model
			var mappedResponseModel = mapper.MapToResponseModel(user, jwtToken);
			return ArfBlocksResults.Success(mappedResponseModel);
		}
	}
}