namespace Application.RequestHandlers.TodoTasks.Queries.Statistics;

public class DataAccess : IDataAccess
{
	private readonly ApplicationDbContext _dbContext;

	public DataAccess(ArfBlocksDependencyProvider depencyProvider)
	{
		_dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
	}

	public async Task<int> GetMyCreationsCountById(Guid userId)
	{
		return await _dbContext.Tasks
									.Include(x => x.AssignedDepartment)
									.Include(x => x.CreatedBy)
									.Where(x => x.CreatedById == userId)
									.CountAsync();
	}

	public async Task<int> GetWaitingForMyApprovalsCountById(Guid departmentId)
	{
		return await _dbContext.Tasks
									.Include(x => x.AssignedDepartment)
									.Include(x => x.CreatedBy)
									.Where(x => x.AssignedDepartmentId == departmentId && x.Status == TodoTaskStatus.Pending)
									.CountAsync();
	}
}