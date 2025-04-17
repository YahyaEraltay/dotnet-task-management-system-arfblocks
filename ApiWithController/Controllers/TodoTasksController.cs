namespace ApiWithController.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class TodoTasksController : ControllerBase
{
    private readonly ArfBlocksRequestOperator _requestOperator;

    public TodoTasksController(ArfBlocksDependencyProvider dependencyProvider)
    {
        _requestOperator = new ArfBlocksRequestOperator(dependencyProvider);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<List<Application.RequestHandlers.TodoTasks.Commands.Create.ResponseModel>>> Create(Application.RequestHandlers.TodoTasks.Commands.Create.RequestModel payload)
    {
        return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.TodoTasks.Commands.Create.Handler>(payload);
    }

    [HttpPut("[action]")]
    public async Task<ActionResult<List<Application.RequestHandlers.TodoTasks.Commands.Update.ResponseModel>>> Update(Application.RequestHandlers.TodoTasks.Commands.Update.RequestModel payload)
    {
        return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.TodoTasks.Commands.Update.Handler>(payload);
    }

    [HttpDelete("[action]")]
    public async Task<ActionResult<List<Application.RequestHandlers.TodoTasks.Commands.Delete.ResponseModel>>> Delete(Application.RequestHandlers.TodoTasks.Commands.Delete.RequestModel payload)
    {
        return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.TodoTasks.Commands.Delete.Handler>(payload);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<List<Application.RequestHandlers.TodoTasks.Commands.Complete.ResponseModel>>> Complete(Application.RequestHandlers.TodoTasks.Commands.Complete.RequestModel payload)
    {
        return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.TodoTasks.Commands.Complete.Handler>(payload);
    }

    [HttpPost("[action]")]
    public async Task<ActionResult<List<Application.RequestHandlers.TodoTasks.Commands.Reject.ResponseModel>>> Reject(Application.RequestHandlers.TodoTasks.Commands.Reject.RequestModel payload)
    {
        return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.TodoTasks.Commands.Reject.Handler>(payload);
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<List<Application.RequestHandlers.TodoTasks.Queries.All.ResponseModel>>> All()
    {
        return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.TodoTasks.Queries.All.Handler>(null);
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<List<Application.RequestHandlers.TodoTasks.Queries.Pendings.ResponseModel>>> Pendings()
    {
        return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.TodoTasks.Queries.Pendings.Handler>(null);
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<List<Application.RequestHandlers.TodoTasks.Queries.MyTasks.ResponseModel>>> MyTasks()
    {
        return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.TodoTasks.Queries.MyTasks.Handler>(null);
    }

    [HttpGet("[action]")]
    public async Task<ActionResult<Application.RequestHandlers.TodoTasks.Queries.Detail.ResponseModel>> Detail(Application.RequestHandlers.TodoTasks.Queries.Detail.RequestModel payload)
    {
        return await _requestOperator.OperateHttpRequest<Application.RequestHandlers.TodoTasks.Queries.Detail.Handler>(payload);
    }

}