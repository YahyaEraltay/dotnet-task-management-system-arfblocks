namespace Application.RequestHandlers.Users.Queries.All
{
	public class DataAccess : IDataAccess
	{
		private readonly ApplicationDbContext _dbContext;

		public DataAccess(ArfBlocksDependencyProvider depencyProvider)
		{
			_dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
		}

		public async Task<(List<User>, XPageResponse)> GetAllUsers(XSorting sorting, List<XFilterItem> filters, XPageRequest pageRequest)
		{
			var query = _dbContext.Users
										.Include(d => d.Department)
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
}