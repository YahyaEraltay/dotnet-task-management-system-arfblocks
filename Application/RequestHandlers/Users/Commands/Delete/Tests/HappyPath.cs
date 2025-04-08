namespace Application.RequestHandlers.Users.Commands.Delete.Test;

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
        await Task.CompletedTask;
    }

    public async Task RunTest()
    {
        await Test();
    }

    private async Task Test()
    {
        var requestPayload = new Application.RequestHandlers.Users.Commands.Delete.RequestModel()
        {
            Id = user.Id,
            IsDeleted = true,
        };

        var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
        var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.Users.Commands.Delete.Handler>(requestPayload);
        if (response.HasError)
            throw new Exception(response.Error.Message);

        response.HasError.Should().Be(false);

        var responsePayload = (Application.RequestHandlers.Users.Commands.Delete.ResponseModel)response.Payload;
        responsePayload.Id.Should().NotBeEmpty().And.NotBe(Guid.Empty);
        responsePayload.Id.Should().Be(user.Id);

        var userOnDb = await _dbContextOperation.GetById<User>(responsePayload.Id);
        userOnDb.Id.Should().Be(requestPayload.Id);
        userOnDb.IsDeleted.Should().Be(requestPayload.IsDeleted);
    }
}