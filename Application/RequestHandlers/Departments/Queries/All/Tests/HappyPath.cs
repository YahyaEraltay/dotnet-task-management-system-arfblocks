namespace Application.RequestHandlers.Departments.Queries.All.Test;

public class HappyPath : IArfBlocksTest
{
    private DbContextOperations<Department> _dbContextOperation;

    private ArfBlocksDependencyProvider _dependencyProvider;

    public void SetDependencies(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dependencyProvider = dependencyProvider;
        var _dbContext = dependencyProvider.GetInstance<ApplicationDbContext>();
        _dbContextOperation = new DbContextOperations<Department>(_dbContext);
    }

    Department department = null;
    public async Task PrepareTest()
    {
        department = TestDefinitions.Departments.DefaultDepartment();
        await _dbContextOperation.Create<Department>(department);
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
        var requestPayload = new Application.RequestHandlers.Departments.Queries.All.RequestModel()
        {
            PageRequest = new XPageRequest()
            {
                ListAll = true,
                CurrentPage = 1,
                PerPageCount = 1,
            },
        };

        var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
        var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.Departments.Queries.All.Handler>(requestPayload);
        if (response.HasError)
            throw new Exception(response.Error.Message);

        response.HasError.Should().Be(false);

        var responsePayload = (List<Application.RequestHandlers.Departments.Queries.All.ResponseModel>)response.Payload;
        var matchedDepartment = responsePayload.FirstOrDefault(d => d.Id == department.Id);
        matchedDepartment.Should().NotBeNull();
        matchedDepartment.Id.Should().Be(department.Id);
        matchedDepartment.Name.Should().Be(department.Name);
    }

}