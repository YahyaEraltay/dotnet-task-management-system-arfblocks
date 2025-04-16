namespace Infrastructure.RelationalDB;

public class TestDataSeeder
{
    private readonly ApplicationDbContext _dbContext;
    public TestDataSeeder(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Seed()
    {
        _dbContext.Departments.AddRange(DefaultData.DefaultDepartments);
        _dbContext.Users.AddRange(DefaultData.DefaultUsers);
        _dbContext.Tasks.AddRange(DefaultData.DefaultTodoTasks);

        await _dbContext.SaveChangesAsync();
    }
}