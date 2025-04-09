// namespace Application.RequestHandlers.Users.Queries.Me.Test;

// public class HappyPath : IArfBlocksTest
// {
//     private DbContextOperations<User> _dbContextOperation;

//     private ArfBlocksDependencyProvider _dependencyProvider;

//     public void SetDependencies(ArfBlocksDependencyProvider dependencyProvider)
//     {
//         _dependencyProvider = dependencyProvider;
//         var _dbContext = dependencyProvider.GetInstance<ApplicationDbContext>();
//         _dbContextOperation = new DbContextOperations<User>(_dbContext);
//     }

//     Department department = null;
//     User user = null;
//     public async Task PrepareTest()
//     {
//         department = TestDefinitions.Departments.DefaultDepartment();
//         await _dbContextOperation.Create<Department>(department);

//         user = TestDefinitions.Users.DefaultUser(department.Id);
//         await _dbContextOperation.Create<User>(user);
//     }

//     public async Task SetActor()
//     {
//         // NOP:
//         await Task.CompletedTask;
//     }

//     public async Task RunTest()
//     {
//         await Test();
//     }

//     private async Task Test()
//     {
//         var requestPayload = new Application.RequestHandlers.Users.Queries.Me.RequestModel()
//         {
//         };

//         var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
//         var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.Users.Queries.Me.Handler>(requestPayload);

//         if (response.HasError)
//             throw new Exception(response.Error.Message);

//         response.HasError.Should().Be(false);

//         var responsePayload = (Application.RequestHandlers.Users.Queries.Me.ResponseModel)response.Payload;
//         responsePayload.Id.Should().Be(user.Id);
//         responsePayload.Email.Should().Be(user.Email);
//         responsePayload.DisplayName.Should().Be($"{user.FirstName} {user.LastName}");
//         responsePayload.DepartmentId.Should().Be(user.DepartmentId);
//         responsePayload.DepartmentName.Should().Be(user.Department.Name);
//     }
// }