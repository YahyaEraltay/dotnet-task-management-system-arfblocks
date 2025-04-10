namespace Application.RequestHandlers.TodoTasks.Queries.Pendings
{
	public class DataAccess : IDataAccess
	{
		private readonly ApplicationDbContext _dbContext;

		public DataAccess(ArfBlocksDependencyProvider depencyProvider)
		{
			_dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
		}

		public async Task<User> GetUserById(Guid userId)
		{
			return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
		}
		public async Task<List<TodoTask>> GetPendingTasks(Guid departmentId)
		{
			return await _dbContext.Tasks
										.Include(d => d.AssignedDepartment)
										.Include(d => d.CreatedBy)
										.Where(d => !d.IsDeleted && d.Status == TodoTaskStatus.Pending && d.AssignedDepartmentId == departmentId)
										.OrderByDescending(i => i.CreatedAt)
										.ToListAsync();
		}
	}
}