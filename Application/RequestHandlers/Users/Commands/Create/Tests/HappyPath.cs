namespace Application.RequestHandlers.Users.Commands.Create.Test;

public class HappyPath : IArfBlocksTest
{
    private DbContextOperations<User> _dbContextOperation;

    private ArfBlocksDependencyProvider _dependencyProvider;

    public void SetDependencies(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dependencyProvider = dependencyProvider;
        var _dbContext = dependencyProvider.GetInstance<ApplicationDbContext>();
        _dbContextOperation = new DbContextOperations<User>(_dbContext);
    }
    public async Task SetActor()
    {
        await Task.CompletedTask;

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

    public async Task RunTest()
    {
        await Test();
    }

    private async Task Test()
    {
        var requestPayload = new Application.RequestHandlers.Users.Commands.Create.RequestModel()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            DepartmentId = department.Id,
        };

        var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
        var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.Users.Commands.Create.Handler>(requestPayload);
        if (response.HasError)
            throw new Exception(response.Error.Message);

        response.HasError.Should().Be(false);

        var responsePayload = (Application.RequestHandlers.Users.Commands.Create.ResponseModel)response.Payload;
        responsePayload.Id.Should().NotBeEmpty().And.NotBe(Guid.Empty);
        responsePayload.FirstName.Should().Be(requestPayload.FirstName);
        responsePayload.LastName.Should().Be(requestPayload.LastName);

        var userOnDb = await _dbContextOperation.GetById<User>(responsePayload.Id);
        userOnDb.FirstName.Should().Be(requestPayload.FirstName);
        userOnDb.LastName.Should().Be(requestPayload.LastName);
        userOnDb.Email.Should().Be(requestPayload.Email);
        userOnDb.DepartmentId.Should().Be(requestPayload.DepartmentId);
    }

}