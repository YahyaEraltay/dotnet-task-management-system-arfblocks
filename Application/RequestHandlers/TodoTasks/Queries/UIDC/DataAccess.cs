namespace Application.RequestHandlers.TodoTasks.Queries.UIDC;

public class DataAccess : IDataAccess
{
    private readonly ApplicationDbContext _dbContext;

    public DataAccess(ArfBlocksDependencyProvider depencyProvider)
    {
        _dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
    }

    public async Task<TodoTask> GetTodoTaskById(Guid taskId)
    {
        return await _dbContext.Tasks
                                 .FirstOrDefaultAsync(s => s.Id == taskId);
    }

    public async Task<bool> IsUserTaskOwner(Guid todoTaskId, Guid userId)
    {
        return await _dbContext.Tasks.AnyAsync(s => s.CreatedById == userId && s.Id == todoTaskId);
    }

    public async Task<bool> IsDepartmentsMatched(Guid todoTaskId, Guid departmentId)
    {
        return await _dbContext.Tasks.AnyAsync(s => s.AssignedDepartmentId == departmentId && s.Id == todoTaskId);
    }
}