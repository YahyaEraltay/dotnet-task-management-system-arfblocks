namespace ApiWithController.Controllers
{
	[ApiController]
	[Route("[controller]")]
	[Produces("application/json")]
	public class UsersController : ControllerBase
	{
		private readonly ArfBlocksRequestOperator _requestOperator;

		public UsersController(ArfBlocksDependencyProvider dependencyProvider)
		{
			_requestOperator = new ArfBlocksRequestOperator(dependencyProvider);
		}

		[HttpPost("[action]")]
		public async Task<ActionResult<List<Application.RequestHandlers.Users.Commands.Create.ResponseModel>>> Create(Application.RequestHandlers.Users.Commands.Create.RequestModel payload)
		{
			return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Users.Commands.Create.Handler>(payload);
		}

		[HttpPut("[action]")]
		public async Task<ActionResult<List<Application.RequestHandlers.Users.Commands.Update.ResponseModel>>> Update(Application.RequestHandlers.Users.Commands.Update.RequestModel payload)
		{
			return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Users.Commands.Update.Handler>(payload);
		}

		[HttpDelete("[action]")]
		public async Task<ActionResult<List<Application.RequestHandlers.Users.Commands.Delete.ResponseModel>>> Delete(Application.RequestHandlers.Users.Commands.Delete.RequestModel payload)
		{
			return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Users.Commands.Delete.Handler>(payload);
		}

		[AllowAnonymous]
		[HttpPost("[action]")]
		public async Task<ActionResult<List<Application.RequestHandlers.Users.Commands.Login.ResponseModel>>> Login(Application.RequestHandlers.Users.Commands.Login.RequestModel payload)
		{
			return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Users.Commands.Login.Handler>(payload);
		}

		[HttpGet("[action]")]
		public async Task<ActionResult<List<Application.RequestHandlers.Users.Queries.All.ResponseModel>>> All()
		{
			return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Users.Queries.All.Handler>(null);
		}

		[HttpGet("[action]")]
		public async Task<ActionResult<List<Application.RequestHandlers.Users.Queries.Me.ResponseModel>>> Me()
		{
			return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Users.Queries.Me.Handler>(null);
		}

		[HttpGet("[action]")]
		public async Task<ActionResult<Application.RequestHandlers.Users.Queries.Detail.ResponseModel>> Detail(Application.RequestHandlers.Users.Queries.Detail.RequestModel payload)
		{
			return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Users.Queries.Detail.Handler>(payload);
		}
	}
}
