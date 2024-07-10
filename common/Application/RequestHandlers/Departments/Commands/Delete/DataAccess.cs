namespace Application.RequestHandlers.Departments.Commands.Delete
{
    public class DataAccess : IDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public DataAccess(ArfBlocksDependencyProvider depencyProvider)
        {
            _dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
        }

        public async Task<Department> GetById(Guid departmentId)
        {
            return await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == departmentId);
        }

        public async Task Update(Department department)
        {
            _dbContext.Departments.Update(department);
            await _dbContext.SaveChangesAsync();
        }
    }
}