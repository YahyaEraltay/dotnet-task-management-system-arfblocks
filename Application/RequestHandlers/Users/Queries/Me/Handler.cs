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

			var user = await _dataAccessLayer.GetUserById(currentUserId);
			System.Console.WriteLine("--------------------");
			System.Console.WriteLine(user.Id);
			System.Console.WriteLine(user.Email);
			System.Console.WriteLine(user.FirstName);
			System.Console.WriteLine(user.LastName);
			System.Console.WriteLine(user.DepartmentId);
			System.Console.WriteLine(user.Department.Name);





			var response = mapper.MapToResponse(user);
			return ArfBlocksResults.Success(response);
		}
	}
}