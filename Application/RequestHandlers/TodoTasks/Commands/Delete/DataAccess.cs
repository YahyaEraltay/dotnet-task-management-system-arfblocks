namespace Application.RequestHandlers.TodoTasks.Commands.Delete;

public class DataAccess : IDataAccess
{
    private readonly ApplicationDbContext _dbContext;

    public DataAccess(ArfBlocksDependencyProvider depencyProvider)
    {
        _dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
    }

    public async Task<TodoTask> GetTaskById(Guid id)
    {
        return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task Update(TodoTask task)
    {
        _dbContext.Tasks.Update(task);
        await _dbContext.SaveChangesAsync();
    }
}