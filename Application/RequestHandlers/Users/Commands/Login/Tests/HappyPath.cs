namespace Application.RequestHandlers.Users.Commands.Login.Test;

public class HappyPath_AdminUser : IArfBlocksTest
{
    private DbContextOperations<User> _dbContextOperation;

    private ArfBlocksDependencyProvider _dependencyProvider;

    public void SetDependencies(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dependencyProvider = dependencyProvider;
        var _dbContext = dependencyProvider.GetInstance<ApplicationDbContext>();
        _dbContextOperation = new DbContextOperations<User>(_dbContext);
    }

    Department department = null;
    User user = null;
    public async Task PrepareTest()
    {
        department = TestDefinitions.Departments.DefaultDepartment();
        await _dbContextOperation.Create<Department>(department);

        user = TestDefinitions.Users.DefaultUser(department.Id);
        await _dbContextOperation.Create<User>(user);
    }


    public async Task SetActor()
    {
        // NOP:
        await Task.CompletedTask;
    }

    public async Task RunTest()
    {
        await Test();
    }

    private async Task Test()
    {
        var requestPayload = new Application.RequestHandlers.Users.Commands.Login.RequestModel()
        {
            Email = user.Email,
        };

        var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
        var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.Users.Commands.Login.Handler>(requestPayload);
        if (response.HasError)
            throw new Exception(response.Error.Message);

        response.HasError.Should().Be(false);

        var responsePayload = (Application.RequestHandlers.Users.Commands.Login.ResponseModel)response.Payload;
        responsePayload.JwtToken.Should().NotBeEmpty().And.Contain(".", Exactly.Twice());
        responsePayload.UserId.Should().Be(user.Id);
        responsePayload.Email.Should().Be(user.Email);
        responsePayload.DisplayName.Should().Be($"{user.FirstName} {user.LastName}");
        responsePayload.Department.Id.Should().Be(user.DepartmentId);
        responsePayload.Department.Name.Should().Be(user.Department.Name);
    }
}