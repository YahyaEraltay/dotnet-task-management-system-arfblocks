namespace ApiWithController.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class DepartmentsController : ControllerBase
{
	private readonly ArfBlocksRequestOperator _requestOperator;

	public DepartmentsController(ArfBlocksDependencyProvider dependencyProvider)
	{
		_requestOperator = new ArfBlocksRequestOperator(dependencyProvider);
	}

	[HttpPost("[action]")]
	public async Task<ActionResult<List<Application.RequestHandlers.Departments.Commands.Create.ResponseModel>>> Create(Application.RequestHandlers.Departments.Commands.Create.RequestModel payload)
	{
		return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Departments.Commands.Create.Handler>(payload);
	}

	[HttpPut("[action]")]
	public async Task<ActionResult<List<Application.RequestHandlers.Departments.Commands.Update.ResponseModel>>> Update(Application.RequestHandlers.Departments.Commands.Update.RequestModel payload)
	{
		return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Departments.Commands.Update.Handler>(payload);
	}

	[HttpDelete("[action]")]
	public async Task<ActionResult<List<Application.RequestHandlers.Departments.Commands.Delete.ResponseModel>>> Delete(Application.RequestHandlers.Departments.Commands.Delete.RequestModel payload)
	{
		return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Departments.Commands.Delete.Handler>(payload);
	}

	[HttpGet("[action]")]
	public async Task<ActionResult<List<Application.RequestHandlers.Departments.Queries.All.ResponseModel>>> All()
	{
		return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Departments.Queries.All.Handler>(null);
	}

	[HttpGet("[action]")]
	public async Task<ActionResult<Application.RequestHandlers.Departments.Queries.Detail.ResponseModel>> Detail(Application.RequestHandlers.Departments.Queries.Detail.RequestModel payload)
	{
		return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.Departments.Queries.Detail.Handler>(payload);
	}
}