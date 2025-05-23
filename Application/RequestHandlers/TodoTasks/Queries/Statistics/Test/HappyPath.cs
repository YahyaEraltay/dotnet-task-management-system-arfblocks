namespace Application.RequestHandlers.TodoTasks.Queries.Statistics.Test;

public class HappyPath : IArfBlocksTest
{
    private DbContextOperations<TodoTask> _dbContextOperation;

    private ArfBlocksDependencyProvider _dependencyProvider;

    public void SetDependencies(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dependencyProvider = dependencyProvider;
        var _dbContext = dependencyProvider.GetInstance<ApplicationDbContext>();
        _dbContextOperation = new DbContextOperations<TodoTask>(_dbContext);
    }
    public async Task SetActor()
    {
        await Task.CompletedTask;

    }

    Department department = null;
    User user = null;
    TodoTask todoTask = null;
    public async Task PrepareTest()
    {
        department = TestDefinitions.Departments.DefaultDepartment();
        await _dbContextOperation.Create<Department>(department);

        user = TestDefinitions.Users.DefaultUser(department.Id);
        await _dbContextOperation.Create<User>(user);

        todoTask = TestDefinitions.ToDoTasks.DefaultTask(user.Id, user.Department.Id, TodoTaskStatus.Pending);
        await _dbContextOperation.Create<TodoTask>(todoTask);
    }

    public async Task RunTest()
    {
        await Test();
    }

    private async Task Test()
    {
        var requestPayload = new Application.RequestHandlers.TodoTasks.Queries.Statistics.RequestModel()
        {
        };

        var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
        var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.TodoTasks.Queries.Statistics.Handler>(requestPayload);
        if (response.HasError)
            throw new Exception(response.Error.Message);

        response.HasError.Should().Be(false);

        var responsePayload = (Application.RequestHandlers.TodoTasks.Queries.Statistics.ResponseModel)response.Payload;
        responsePayload.WaitingForMyApprovals.Should().BeGreaterThanOrEqualTo(0);
        responsePayload.MyCreations.Should().BeGreaterThanOrEqualTo(0);
    }
}