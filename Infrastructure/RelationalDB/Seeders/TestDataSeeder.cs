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
        _dbContext.Users.AddRange(DefaultUserData.DefaultUsers);

        await _dbContext.SaveChangesAsync();
    }
}