namespace Application.RequestHandlers.Departments.Commands.Create.Test;

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
    public async Task SetActor()
    {
        await Task.CompletedTask;

    }

    Department department = null;

    public async Task PrepareTest()
    {
        department = TestDefinitions.Departments.DefaultDepartment();
        await _dbContextOperation.Create<Department>(department);
    }

    public async Task RunTest()
    {
        await Test();
    }

    private async Task Test()
    {
        var requestPayload = new Application.RequestHandlers.Departments.Commands.Create.RequestModel()
        {
            Name = department.Name,
        };

        var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
        var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.Departments.Commands.Create.Handler>(requestPayload);
        if (response.HasError)
            throw new Exception(response.Error.Message);

        response.HasError.Should().Be(false);

        var responsePayload = (Application.RequestHandlers.Departments.Commands.Create.ResponseModel)response.Payload;
        responsePayload.Id.Should().NotBeEmpty().And.NotBe(Guid.Empty);
        responsePayload.Name.Should().Be(requestPayload.Name);

        var departmentOnDb = await _dbContextOperation.GetById<Department>(responsePayload.Id);
        departmentOnDb.Name.Should().Be(requestPayload.Name);
    }

}