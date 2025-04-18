namespace Application.RequestHandlers.Apps.Queries.UISC;

public class DataAccess : IDataAccess
{
    private readonly ApplicationDbContext _dbContext;

    public DataAccess(ArfBlocksDependencyProvider depencyProvider)
    {
        _dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
    }

    public async Task<bool> IsUserHaveTask(Guid departmentId)
    {
        return await _dbContext.Tasks.AnyAsync(x => x.AssignedDepartmentId == departmentId);
    }
}