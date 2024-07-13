namespace Application.RequestHandlers.Users.Commands.Update
{
    public class DataAccess : IDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public DataAccess(ArfBlocksDependencyProvider depencyProvider)
        {
            _dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);  
        }

        public async Task Update(User user)
        {
            var updatedUser = await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == user.Id);
            
            _dbContext.Departments.Update(updatedUser);
            await _dbContext.SaveChangesAsync();
        }
    }
}