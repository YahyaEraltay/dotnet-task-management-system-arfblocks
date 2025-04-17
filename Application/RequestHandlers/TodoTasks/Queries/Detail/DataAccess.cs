namespace Application.RequestHandlers.TodoTasks.Queries.Detail;

public class DataAccess : IDataAccess
{
	private readonly ApplicationDbContext _dbContext;

	public DataAccess(ArfBlocksDependencyProvider depencyProvider)
	{
		_dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
	}

	public async Task<TodoTask> GetTaskById(Guid id)
	{
		return await _dbContext.Tasks
									.Include(t => t.AssignedDepartment)
									.Include(t => t.CreatedBy)
									.FirstOrDefaultAsync(d => !d.IsDeleted && d.Id == id);
	}
}