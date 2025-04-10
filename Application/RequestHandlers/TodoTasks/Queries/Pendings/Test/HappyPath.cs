// namespace Application.RequestHandlers.TodoTasks.Queries.Pendings.Test;

// public class HappyPath : IArfBlocksTest
// {
//     private DbContextOperations<TodoTask> _dbContextOperation;

//     private ArfBlocksDependencyProvider _dependencyProvider;

//     public void SetDependencies(ArfBlocksDependencyProvider dependencyProvider)
//     {
//         _dependencyProvider = dependencyProvider;
//         var _dbContext = dependencyProvider.GetInstance<ApplicationDbContext>();
//         _dbContextOperation = new DbContextOperations<TodoTask>(_dbContext);
//     }
//     public async Task SetActor()
//     {
//         await Task.CompletedTask;

//     }

//     User user = null;
//     TodoTask todoTask = null;
//     public async Task PrepareTest()
//     {
//         user = TestDefinitions.Users.DefaultUser(TestDefinitions.Actors.CurrentUser.DepartmentId);
//         await _dbContextOperation.Create<User>(user);

//         todoTask = TestDefinitions.ToDoTasks.DefaultTask(TestDefinitions.Actors.CurrentUser.Id, TestDefinitions.Actors.CurrentUser.DepartmentId, TodoTaskStatus.Pending);
//         await _dbContextOperation.Create<TodoTask>(todoTask);
//     }

//     public async Task RunTest()
//     {
//         await Test();
//     }

//     private async Task Test()
//     {
//         var requestPayload = new Application.RequestHandlers.TodoTasks.Queries.Pendings.RequestModel()
//         {
//         };

//         var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
//         var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.TodoTasks.Queries.Pendings.Handler>(requestPayload);
//         if (response.HasError)
//             throw new Exception(response.Error.Message);

//         response.HasError.Should().Be(false);

//         var responsePayload = (List<Application.RequestHandlers.TodoTasks.Queries.Pendings.ResponseModel>)response.Payload;
//         var matchedTodoTask = responsePayload.FirstOrDefault(d => d.Id == todoTask.Id);
//         matchedTodoTask.Should().NotBeNull();
//         matchedTodoTask.Id.Should().Be(todoTask.Id);
//         matchedTodoTask.Title.Should().Be(todoTask.Title);
//         matchedTodoTask.Description.Should().Be(todoTask.Description);
//         matchedTodoTask.Status.Should().Be(todoTask.Status);
//         matchedTodoTask.AssignedDepartment.Id.Should().Be(todoTask.AssignedDepartmentId);
//         matchedTodoTask.AssignedDepartment.Name.Should().Be(todoTask.AssignedDepartment.Name);
//         matchedTodoTask.CreatedBy.Id.Should().Be(todoTask.CreatedById);
//         matchedTodoTask.CreatedBy.DisplayName.Should().Be($"{todoTask.CreatedBy.FirstName} {todoTask.CreatedBy.LastName}");
//     }
// }