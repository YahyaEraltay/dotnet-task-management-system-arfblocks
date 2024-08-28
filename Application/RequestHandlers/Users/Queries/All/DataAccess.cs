namespace Application.RequestHandlers.Users.Queries.All
{
	public class DataAccess : IDataAccess
	{
		private readonly ApplicationDbContext _dbContext;

		public DataAccess(ArfBlocksDependencyProvider depencyProvider)
		{
			_dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
		}

		public async Task<List<User>> All()
		{
			return await _dbContext.Users
										.Include(d => d.Department)
										.Where(d => !d.IsDeleted)
										.OrderBy(i => i.FirstName)
										.ToListAsync();
		}
	}
}