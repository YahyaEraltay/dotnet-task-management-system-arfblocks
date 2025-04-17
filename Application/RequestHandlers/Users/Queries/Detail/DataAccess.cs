namespace Application.RequestHandlers.Users.Queries.Detail;

public class DataAccess : IDataAccess
{
	private readonly ApplicationDbContext _dbContext;

	public DataAccess(ArfBlocksDependencyProvider depencyProvider)
	{
		_dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
	}

	public async Task<User> GetUserById(Guid Id)
	{
		return await _dbContext.Users
									.Include(x => x.Department)
									.FirstOrDefaultAsync(x => x.Id == Id);
	}
}