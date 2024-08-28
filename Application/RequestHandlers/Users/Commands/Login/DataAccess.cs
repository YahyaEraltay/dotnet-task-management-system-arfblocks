namespace Application.RequestHandlers.Users.Commands.Login
{
	public class DataAccess : IDataAccess
	{
		private readonly ApplicationDbContext _dbContext;

		public DataAccess(ArfBlocksDependencyProvider depencyProvider)
		{
			_dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
		}

		public async Task<User> GetUserByEmail(string email)
		{
			return await _dbContext.Users
										.Include(u => u.Department)
										.FirstOrDefaultAsync(u => u.Email == email);
		}
	}
}