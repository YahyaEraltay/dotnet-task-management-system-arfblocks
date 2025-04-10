namespace Application.RequestHandlers.Users.Commands.Delete
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
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}