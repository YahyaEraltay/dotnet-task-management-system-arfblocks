namespace Application.RequestHandlers.TodoTasks.Queries.MyTasks;

public class DataAccess : IDataAccess
{
	private readonly ApplicationDbContext _dbContext;

	public DataAccess(ArfBlocksDependencyProvider depencyProvider)
	{
		_dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
	}

	public async Task<(List<TodoTask>, XPageResponse)> GetAllPendingTasksByUserId(XSorting sorting, List<XFilterItem> filters, XPageRequest pageRequest, Guid userId)
	{
		var query = _dbContext.Tasks
									.Include(d => d.AssignedDepartment)
									.Include(d => d.CreatedBy)
									.Where(d => d.CreatedById == userId)
									.Sort(sorting)
									.Filter(filters);

		if (sorting == null)
			query = query.OrderByDescending(c => c.CreatedAt);

		var page = query.GetPage(pageRequest);

		var list = await query
			.Paginate(page)
			.ToListAsync();

		return (list, page);
	}
}