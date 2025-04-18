namespace Application.RequestHandlers.Departments.Commands.Delete;

public class DataAccess : IDataAccess
{
    private readonly ApplicationDbContext _dbContext;

    public DataAccess(ArfBlocksDependencyProvider depencyProvider)
    {
        _dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
    }

    public async Task<Department> GetDepartmentById(Guid id)
    {
        return await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateDepartment(Department department)
    {
        _dbContext.Departments.Update(department);
        await _dbContext.SaveChangesAsync();
    }
}