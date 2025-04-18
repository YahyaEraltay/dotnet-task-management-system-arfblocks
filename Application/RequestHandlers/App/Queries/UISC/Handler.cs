namespace Application.RequestHandlers.Apps.Queries.UISC;

public class Handler : IRequestHandler
{
    private readonly CurrentUserService _currentUser;
    private readonly DataAccess _dataAccessLayer;

    public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
    {
        _currentUser = dependencyProvider.GetInstance<CurrentUserService>();
        _dataAccessLayer = (DataAccess)dataAccess;
    }

    public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
    {
        var requestPayload = (RequestModel)payload;
        var currentUser = _currentUser.GetCurrentUser();

        var isUserHaveTask = await _dataAccessLayer.IsUserHaveTask(currentUser.DepartmentId);
        // Build UIDC
        var response = await GetUISC(currentUser, isUserHaveTask);

        return ArfBlocksResults.Success(response);
    }

    private async Task<ResponseModel> GetUISC(CurrentUserModel currentUser, bool isUserHaveTask)
    {
        // NOP:
        await Task.CompletedTask;

        var response = new ResponseModel()
        {
            UserId = currentUser.Id,
            Uisc = new ResponseModel.UISC()
            {
                Pages = new ResponseModel.Pages()
            }
        };

        // Check Object State
        response.Uisc.Pages.Statistics = true;

        // Pages
        response.Uisc.Pages.ListMyTasks = isUserHaveTask;
        response.Uisc.Pages.ListPendings = isUserHaveTask;
        response.Uisc.Pages.ListTodoTasks = true;
        response.Uisc.Pages.ListDepartments = true;
        response.Uisc.Pages.ListUsers = true;

        return response;
    }
}