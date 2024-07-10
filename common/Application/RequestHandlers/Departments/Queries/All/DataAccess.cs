namespace Application.RequestHandlers.Departments.Queries.All
{
	public class DataAccess : IDataAccess
	{
		private readonly ApplicationDbContext _dbContext;

		public DataAccess(ArfBlocksDependencyProvider depencyProvider)
		{
			_dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
		}

		public async Task<List<Department>> All()
		{
			return await _dbContext.Departments
										.Where(d => !d.IsDeleted)
										.OrderBy(i => i.Name)
										.ToListAsync();
		}
	}
}