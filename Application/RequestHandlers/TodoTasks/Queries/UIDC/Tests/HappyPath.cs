namespace Application.RequestHandlers.TodoTasks.Queries.UIDC.Test;

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

    TodoTask todoTask = null;
    public async Task PrepareTest()
    {
        todoTask = TestDefinitions.ToDoTasks.DefaultTask(TestDefinitions.Actors.CurrentUser.Id, TestDefinitions.Actors.CurrentUser.DepartmentId, TodoTaskStatus.Pending);
        await _dbContextOperation.Create<TodoTask>(todoTask);
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
        var requestPayload = new Application.RequestHandlers.TodoTasks.Queries.UIDC.RequestModel()
        {
            Id = todoTask.Id,
        };

        var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
        var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.TodoTasks.Queries.UIDC.Handler>(requestPayload);

        if (response.HasError)
            throw new Exception(response.Error.Message);

        response.HasError.Should().Be(false);
        response.HasError.Should().Be(false);
        var responsePayload = (Application.RequestHandlers.TodoTasks.Queries.UIDC.ResponseModel)response.Payload;
        responsePayload.Id.Should().Be(todoTask.Id);
        responsePayload.Commands.Edit.Should().Be(true);
        responsePayload.Commands.Delete.Should().Be(true);
        responsePayload.Commands.UnDelete.Should().Be(false);
        responsePayload.Commands.Complete.Should().Be(true);
        responsePayload.Commands.Reject.Should().Be(true);
    }
}