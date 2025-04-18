namespace Application.RequestHandlers.Departments.Queries.Detail.Test;

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
        var requestPayload = new Application.RequestHandlers.Departments.Queries.Detail.RequestModel()
        {
            Id = department.Id,
        };

        var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
        var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.Departments.Queries.Detail.Handler>(requestPayload);
        if (response.HasError)
            throw new Exception(response.Error.Message);

        response.HasError.Should().Be(false);

        var responsePayload = (Application.RequestHandlers.Departments.Queries.Detail.ResponseModel)response.Payload;
        responsePayload.Id.Should().Be(department.Id);
        responsePayload.Name.Should().Be(department.Name);

        var departmentOnDb = await _dbContextOperation.GetById<Department>(responsePayload.Id);
        departmentOnDb.Id.Should().Be(requestPayload.Id);
    }

}