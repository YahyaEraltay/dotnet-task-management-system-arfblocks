namespace Application.RequestHandlers.TodoTasks.Queries.MyTasks.Test;

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

        todoTask = TestDefinitions.ToDoTasks.DefaultTask(TestDefinitions.Actors.CurrentUser.Id, TestDefinitions.Actors.CurrentUser.DepartmentId, TodoTaskStatus.Pending);
        await _dbContextOperation.Create<TodoTask>(todoTask);
    }

    public async Task RunTest()
    {
        await Test();
    }

    private async Task Test()
    {
        var requestPayload = new Application.RequestHandlers.TodoTasks.Queries.MyTasks.RequestModel()
        {
            PageRequest = new XPageRequest()
            {
                ListAll = true,
                CurrentPage = 1,
                PerPageCount = 1,
            },
        };

        var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
        var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.TodoTasks.Queries.MyTasks.Handler>(requestPayload);
        if (response.HasError)
            throw new Exception(response.Error.Message);

        response.HasError.Should().Be(false);

        var responsePayload = (List<Application.RequestHandlers.TodoTasks.Queries.MyTasks.ResponseModel>)response.Payload;
        var matchedTodoTask = responsePayload.FirstOrDefault(d => d.Id == todoTask.Id);
        matchedTodoTask.Title.Should().Be(todoTask.Title);
        matchedTodoTask.Description.Should().Be(todoTask.Description);
        matchedTodoTask.Status.Should().Be(todoTask.Status);
        matchedTodoTask.AssignedDepartment.Id.Should().Be(todoTask.AssignedDepartmentId);
        System.Console.WriteLine(todoTask.AssignedDepartment.Name);
        // matchedTodoTask.AssignedDepartment.Name.Should().Be(todoTask.AssignedDepartment.Name);
        // matchedTodoTask.CreatedBy.Id.Should().Be(todoTask.CreatedById);
        // matchedTodoTask.CreatedBy.DisplayName.Should().Be($"{todoTask.CreatedBy.FirstName} {todoTask.CreatedBy.LastName}");
    }
}