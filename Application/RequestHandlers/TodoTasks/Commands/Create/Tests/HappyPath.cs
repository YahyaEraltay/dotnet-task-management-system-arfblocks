namespace Application.RequestHandlers.TodoTasks.Commands.Create.Test;

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

        todoTask = TestDefinitions.ToDoTasks.DefaultTask(TestDefinitions.Actors.CurrentUser.Id, user.Department.Id, TodoTaskStatus.Pending);
        await _dbContextOperation.Create<TodoTask>(todoTask);
    }

    public async Task RunTest()
    {
        await Test();
    }

    private async Task Test()
    {
        var requestPayload = new Application.RequestHandlers.TodoTasks.Commands.Create.RequestModel()
        {
            Title = todoTask.Title,
            Description = todoTask.Description,
            AssignedDepartmentId = todoTask.AssignedDepartmentId,
        };

        var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
        var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.TodoTasks.Commands.Create.Handler>(requestPayload);
        if (response.HasError)
            throw new Exception(response.Error.Message);

        response.HasError.Should().Be(false);

        var responsePayload = (Application.RequestHandlers.TodoTasks.Commands.Create.ResponseModel)response.Payload;
        responsePayload.Id.Should().NotBeEmpty().And.NotBe(Guid.Empty);
        responsePayload.Title.Should().Be(requestPayload.Title);
        responsePayload.Description.Should().Be(requestPayload.Description);
        responsePayload.AssignedDepartmentId.Should().Be(requestPayload.AssignedDepartmentId);

        var todoTaskOnDb = await _dbContextOperation.GetById<TodoTask>(responsePayload.Id);
        todoTaskOnDb.Title.Should().Be(requestPayload.Title);
        todoTaskOnDb.Description.Should().Be(requestPayload.Description);
        todoTaskOnDb.AssignedDepartmentId.Should().Be(requestPayload.AssignedDepartmentId);
        todoTaskOnDb.Status.Should().Be(TodoTaskStatus.Pending);
    }

}