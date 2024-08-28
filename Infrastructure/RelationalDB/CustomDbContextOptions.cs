using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.RelationalDB;
public class CustomDbContextOptions
{
    public readonly DbContextOptions<ApplicationDbContext> DbContextOptions;

    public CustomDbContextOptions(RelationalDbConfiguration configuration, EnvironmentService environmentService)
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        if (environmentService.Environment == CustomEnvironments.Test)
            dbContextOptionsBuilder.UseInMemoryDatabase("example-task-db");
        else
            dbContextOptionsBuilder.UseSqlServer(configuration.ConnectionString);

        this.DbContextOptions = dbContextOptionsBuilder.Options;
    }
}