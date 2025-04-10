namespace Application.RequestHandlers.Users.Commands.Update
{
    public class DataAccess : IDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public DataAccess(ArfBlocksDependencyProvider depencyProvider)
        {
            _dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _dbContext.Users
                                         .Include(x => x.Department)
                                         .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateUser(User user)
        {
            var updatedUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            _dbContext.Users.Update(updatedUser);
            await _dbContext.SaveChangesAsync();
        }
    }
}