namespace Application.RequestHandlers.Users.Queries.All.Test;

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
        var requestPayload = new Application.RequestHandlers.Users.Queries.All.RequestModel()
        {
            PageRequest = new XPageRequest()
            {
                ListAll = true,
                CurrentPage = 1,
                PerPageCount = 1,
            },
        };

        var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
        var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.Users.Queries.All.Handler>(requestPayload);
        if (response.HasError)
            throw new Exception(response.Error.Message);

        response.HasError.Should().Be(false);

        var responsePayload = (List<Application.RequestHandlers.Users.Queries.All.ResponseModel>)response.Payload;
        var matchedUser = responsePayload.FirstOrDefault(d => d.Id == user.Id);
        matchedUser.Should().NotBeNull();
        matchedUser.Id.Should().Be(user.Id);
        matchedUser.Email.Should().Be(user.Email);
        matchedUser.FirstName.Should().Be(user.FirstName);
        matchedUser.LastName.Should().Be(user.LastName);
        matchedUser.DisplayName.Should().Be($"{user.FirstName} {user.LastName}");
        matchedUser.DepartmentId.Should().Be(user.DepartmentId);
        matchedUser.DepartmentName.Should().Be(user.Department.Name);
    }

}