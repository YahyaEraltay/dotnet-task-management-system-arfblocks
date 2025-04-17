namespace Application.RequestHandlers.TodoTasks.Commands.Complete;

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

    public async Task UpdateTask(TodoTask task)
    {
        var completedTask = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == task.Id);

        _dbContext.Tasks.Update(completedTask);
        await _dbContext.SaveChangesAsync();
    }
}