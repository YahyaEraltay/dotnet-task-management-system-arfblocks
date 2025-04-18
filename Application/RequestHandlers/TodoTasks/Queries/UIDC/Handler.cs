namespace Application.RequestHandlers.TodoTasks.Queries.UIDC;

public class Handler : IRequestHandler
{
    private readonly DataAccess dataAccessLayer;
    private readonly CurrentUserService _currentUser;

    public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
    {
        dataAccessLayer = (DataAccess)dataAccess;
        _currentUser = dependencyProvider.GetInstance<CurrentUserService>();
    }

    public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
    {
        var requestPayload = (RequestModel)payload;
        var currentUser = _currentUser.GetCurrentUser();

        // Get Matched Data From Db
        var todoTask = await dataAccessLayer.GetTodoTaskById(requestPayload.Id);
        var isUserTaskOwner = await dataAccessLayer.IsUserTaskOwner(requestPayload.Id, currentUser.Id);
        var isDepartmentsMatched = await dataAccessLayer.IsDepartmentsMatched(requestPayload.Id, currentUser.DepartmentId);

        // Build UIDC
        var response = await GetUIDC(todoTask, isUserTaskOwner, isDepartmentsMatched);

        return ArfBlocksResults.Success(response);
    }

    private async Task<ResponseModel> GetUIDC(TodoTask todoTask, bool isUserTaskOwner, bool isDepartmentsMatched)
    {
        // NOP:
        await Task.CompletedTask;

        var response = new ResponseModel()
        {
            Id = todoTask.Id,
            Commands = new ResponseModel.UidcCommands(),
        };

        // Check Current User Permission
        response.Commands.Edit = isUserTaskOwner;
        response.Commands.Delete = isUserTaskOwner && !todoTask.IsDeleted;
        response.Commands.UnDelete = isUserTaskOwner && todoTask.IsDeleted;
        response.Commands.Reject = isDepartmentsMatched;
        response.Commands.Complete = isDepartmentsMatched;

        return response;
    }
}