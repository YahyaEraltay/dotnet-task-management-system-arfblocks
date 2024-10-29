namespace Application.Configuration;

public class TestConfigurations : ITestOperations
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ArfBlocksDependencyProvider _dependencyProvider;

    public TestConfigurations(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dependencyProvider = dependencyProvider;
        _dbContext = dependencyProvider.GetInstance<ApplicationDbContext>();
    }

    public async Task PreExecuting()
    {
        System.Console.WriteLine();

        System.Console.WriteLine("- Starting Default DB Seeding...");
        var defaultSeeder = new TestDataSeeder(_dbContext);
        await defaultSeeder.Seed();
        System.Console.WriteLine("  Completed.");
    }

    public async Task PostExecuting()
    {
        // NOP:
        await Task.CompletedTask;
    }
}