namespace Application.RequestHandlers.Departments.Commands.Delete.Tests;

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
        await Task.CompletedTask;
        department = TestDefinitions.Departments.DefaultDepartment(Guid.NewGuid());
        await _dbContextOperation.Create<Department>(department); //TODO:Station projesinde burda delete yok. Olması gerekiyor mu sor
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
        var requestPayload = new Application.RequestHandlers.Departments.Commands.Delete.RequestModel()
        {
            Id = department.Id,
            IsDeleted = true,
        };

        var requestOperator = new ArfBlocksRequestOperator(_dependencyProvider);
        var response = await requestOperator.OperateInternalRequest<Application.RequestHandlers.Departments.Commands.Delete.Handler>(requestPayload);
        if (response.HasError)
            throw new Exception(response.Error.Message);

        response.HasError.Should().Be(false);

        var responsePayload = (Application.RequestHandlers.Departments.Commands.Delete.ResponseModel)response.Payload;
        responsePayload.Id.Should().NotBeEmpty().And.NotBe(Guid.Empty);
        responsePayload.Id.Should().Be(department.Id);
    }
}