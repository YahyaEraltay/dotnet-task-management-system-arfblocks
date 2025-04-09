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

//     Department department = null;
//     User user = null;
//     TodoTask todoTask = null;
//     public async Task PrepareTest()
//     {
//         department = TestDefinitions.Departments.DefaultDepartment();
//         await _dbContextOperation.Create<Department>(department);

//         user = TestDefinitions.Users.DefaultUser(department.Id);
//         await _dbContextOperation.Create<User>(user);

//         todoTask = TestDefinitions.ToDoTasks.DefaultTask(user.Id, user.Department.Id, TodoTaskStatus.Pending);
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

//         var responsePayload = (Application.RequestHandlers.TodoTasks.Queries.Pendings.ResponseModel)response.Payload;
//         responsePayload.Id.Should().Be(todoTask.Id);
//         responsePayload.Title.Should().Be(todoTask.Title);
//         responsePayload.Description.Should().Be(todoTask.Description);
//         responsePayload.Status.Should().Be(todoTask.Status);
//         responsePayload.AssignedDepartment.Id.Should().Be(todoTask.AssignedDepartmentId);
//         responsePayload.AssignedDepartment.Name.Should().Be(todoTask.AssignedDepartment.Name);
//         responsePayload.CreatedBy.Id.Should().Be(todoTask.CreatedById);
//         responsePayload.CreatedBy.DisplayName.Should().Be($"{todoTask.CreatedBy.FirstName} {todoTask.CreatedBy.LastName}");
//     }
// }