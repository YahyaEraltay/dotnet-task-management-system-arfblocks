namespace Application.RequestHandlers.Users.Queries.Me.Test;

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

    public async Task PrepareTest()
    {
        await Task.CompletedTask;
    }

    public async Task SetActor()
    {
        await Task.CompletedTask;
        SwitchUser(TestDefinitions.Actors.CurrentUser);
    }

    public async Task RunTest()
    {
        await Test();
    }

    private async Task Test()
    {
        var requestPayload = new Application.RequestHandlers.Users.Queries.Me.RequestModel()
        {
        };

        var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
        var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.Users.Queries.Me.Handler>(requestPayload);

        if (response.HasError)
            throw new Exception(response.Error.Message);

        response.HasError.Should().Be(false);

        var responsePayload = (Application.RequestHandlers.Users.Queries.Me.ResponseModel)response.Payload;
        responsePayload.Id.Should().Be(TestDefinitions.Actors.CurrentUser.Id);
        responsePayload.Email.Should().Be(TestDefinitions.Actors.CurrentUser.Email);
        responsePayload.DisplayName.Should().Be($"{TestDefinitions.Actors.CurrentUser.FirstName} {TestDefinitions.Actors.CurrentUser.LastName}");
        responsePayload.DepartmentId.Should().Be(TestDefinitions.Actors.CurrentUser.DepartmentId);
        responsePayload.DepartmentName.Should().Be(TestDefinitions.Actors.CurrentUser.DepartmentName);
    }
}