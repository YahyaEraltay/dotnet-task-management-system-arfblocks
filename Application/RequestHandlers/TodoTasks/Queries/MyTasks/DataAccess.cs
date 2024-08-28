namespace Application.RequestHandlers.TodoTasks.Queries.MyTasks
{
	public class DataAccess : IDataAccess
	{
		private readonly ApplicationDbContext _dbContext;

		public DataAccess(ArfBlocksDependencyProvider depencyProvider)
		{
			_dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
		}

		public async Task<List<TodoTask>> GetPendingTasks(Guid userId)
		{
			return await _dbContext.Tasks
										.Include(d => d.AssignedDepartment)
										.Include(d => d.CreatedBy)
										.Where(d => !d.IsDeleted && d.CreatedById == userId)
										.OrderByDescending(i => i.CreatedAt)
										.ToListAsync();
		}
	}
}