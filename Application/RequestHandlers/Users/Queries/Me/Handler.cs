namespace Application.RequestHandlers.Users.Queries.Me
{
	public class Handler : IRequestHandler
	{
		private readonly DataAccess _dataAccessLayer;

		private readonly CurrentUserService _currentUser;

		public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
		{
			_dataAccessLayer = (DataAccess)dataAccess;

			_currentUser = dependencyProvider.GetInstance<CurrentUserService>();
		}

		public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
		{
			var mapper = new Mapper();
			var currentUserId = _currentUser.GetCurrentUserId();

			var user = await _dataAccessLayer
.GetUserById(currentUserId);

			var response = mapper.MapToResponseModel(user);
			return ArfBlocksResults.Success(response);
		}
	}
}