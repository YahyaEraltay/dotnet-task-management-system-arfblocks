namespace Application.RequestHandlers.Users.Commands.Login;

[AllowAnonymousHandler]
public class Handler : IRequestHandler
{
	private readonly DataAccess _dataAccessLayer;

	private readonly CurrentUserService _currentUser;
	private readonly IJwtService _jwtService;

	public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
	{
		_dataAccessLayer = (DataAccess)dataAccess;

		_currentUser = dependencyProvider.GetInstance<CurrentUserService>();
		_jwtService = dependencyProvider.GetInstance<IJwtService>();
	}

	public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var mapper = new Mapper();
		var requestPayload = (RequestModel)payload;

		var user = await _dataAccessLayer.GetUserByEmail(requestPayload.Email);

		var jwtToken = _jwtService.GenerateJwt(user);

		var response = mapper.MapToResponse(user, jwtToken);
		return ArfBlocksResults.Success(response);
	}
}