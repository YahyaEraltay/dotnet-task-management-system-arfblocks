namespace Application.RequestHandlers.Departments.Queries.Detail
{
	public class DataAccess : IDataAccess
	{
		private readonly ApplicationDbContext _dbContext;

		public DataAccess(ArfBlocksDependencyProvider depencyProvider)
		{
			_dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
		}

		public async Task<Department> GetById(Guid Id)
		{
			return await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == Id);
		}
	}
}