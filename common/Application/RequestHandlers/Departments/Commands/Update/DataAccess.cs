namespace Application.RequestHandlers.Departments.Commands.Update
{
    public class DataAccess : IDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public DataAccess(ArfBlocksDependencyProvider depencyProvider)
        {
            _dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
        }

        public async Task<Department> GetById(Guid id)
        {
            return await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);  
        }

        public async Task Update(Department department)
        {
            var updatedDepartment = await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == department.Id);
            
            _dbContext.Departments.Update(updatedDepartment);
            await _dbContext.SaveChangesAsync();
        }
    }
}