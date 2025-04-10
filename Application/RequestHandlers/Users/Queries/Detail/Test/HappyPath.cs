namespace Application.RequestHandlers.Users.Queries.Detail.Test;

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

    public void SwitchUser(CurrentUserModel user)
    {
        _dependencyProvider.Add<CurrentUserModel>(user);
    }

    public async Task SetActor()
    {
        await Task.CompletedTask;
        SwitchUser(TestDefinitions.Actors.CurrentUser);
    }

    public async Task RunTest()
    {
        await Test();
    }

    private async Task Test()
    {
        var requestPayload = new Application.RequestHandlers.Users.Queries.Detail.RequestModel()
        {
            Id = user.Id,
        };

        var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
        var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.Users.Queries.Detail.Handler>(requestPayload);
        if (response.HasError)
            throw new Exception(response.Error.Message);

        response.HasError.Should().Be(false);

        var responsePayload = (Application.RequestHandlers.Users.Queries.Detail.ResponseModel)response.Payload;
        responsePayload.Id.Should().Be(user.Id);
        responsePayload.Email.Should().Be(user.Email);
        responsePayload.FirstName.Should().Be(user.FirstName);
        responsePayload.LastName.Should().Be(user.LastName);
        responsePayload.DepartmentId.Should().Be(user.Department.Id);
        responsePayload.DepartmentName.Should().Be(user.Department.Name);

        var userOnDb = await _dbContextOperation.GetById<User>(responsePayload.Id);
        userOnDb.Id.Should().Be(requestPayload.Id);
    }
}