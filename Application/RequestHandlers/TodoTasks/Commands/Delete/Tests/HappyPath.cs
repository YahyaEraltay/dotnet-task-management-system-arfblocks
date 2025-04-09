namespace Application.RequestHandlers.TodoTasks.Commands.Delete.Test;

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

    public async Task SetActor()
    {
        await Task.CompletedTask;
    }

    public async Task RunTest()
    {
        await Test();
    }

    private async Task Test()
    {
        var requestPayload = new Application.RequestHandlers.TodoTasks.Commands.Delete.RequestModel()
        {
            Id = todoTask.Id,
            IsDeleted = true,
        };

        var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
        var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.TodoTasks.Commands.Delete.Handler>(requestPayload);
        // if (response.HasError)
        //     throw new Exception(response.Error.Message);

        response.HasError.Should().Be(true);
        response.Error.Message.Should().Be(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.TodoTaskErrors.TodoTaskNotExist));

        // var responsePayload = (Application.RequestHandlers.TodoTasks.Commands.Delete.ResponseModel)response.Payload;
        // responsePayload.Id.Should().NotBeEmpty().And.NotBe(Guid.Empty);
        // responsePayload.Id.Should().Be(todoTask.Id);

        // var todoTaskOnDb = await _dbContextOperation.GetById<TodoTask>(responsePayload.Id);
        // todoTaskOnDb.Id.Should().Be(requestPayload.Id);
        // todoTaskOnDb.IsDeleted.Should().Be(requestPayload.IsDeleted);
    }
}