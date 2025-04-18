namespace Application.RequestHandlers.Apps.Queries.UISC.Test;

public class HappyPath : IArfBlocksTest
{
    private DbContextOperations<User> _dbContextOperation;
    private ArfBlocksDependencyProvider _dependencyProvider;
    public void SwitchUser(CurrentUserModel user)
    {
        _dependencyProvider.Add<CurrentUserModel>(user);
    }

    public void SetDependencies(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dependencyProvider = dependencyProvider;
        var _dbContext = dependencyProvider.GetInstance<ApplicationDbContext>();
        _dbContextOperation = new DbContextOperations<User>(_dbContext);
    }
    User user = null;
    public async Task PrepareTest()
    {
        user = TestDefinitions.Users.DefaultUser(TestDefinitions.Actors.CurrentUser.DepartmentId);
        await _dbContextOperation.Create<User>(user);
    }

    public async Task SetActor()
    {
        // NOP:
        await Task.CompletedTask;
        SwitchUser(TestDefinitions.Actors.CurrentUser);
    }

    public async Task RunTest()
    {
        await Test();
    }

    private async Task Test()
    {
        var requestPayload = new Application.RequestHandlers.Apps.Queries.UISC.RequestModel()
        {
        };

        var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
        var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.Apps.Queries.UISC.Handler>(requestPayload);

        if (response.HasError)
            throw new Exception(response.Error.Message);

        response.HasError.Should().Be(false);
        response.HasError.Should().Be(false);

        var responsePayload = (Application.RequestHandlers.Apps.Queries.UISC.ResponseModel)response.Payload;
        responsePayload.Uisc.Pages.ListMyTasks.Should().Be(true);
        responsePayload.Uisc.Pages.ListPendings.Should().Be(true);
    }

}