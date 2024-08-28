namespace Application.RequestHandlers.Users.Queries.Me
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
			return await _dbContext.Users
										.Include(u => u.Department)
										.FirstOrDefaultAsync(u => u.Id == userId);
		}
	}
}