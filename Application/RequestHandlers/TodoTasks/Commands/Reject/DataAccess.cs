namespace Application.RequestHandlers.TodoTasks.Commands.Reject
{
    public class DataAccess : IDataAccess
    {
        private readonly ApplicationDbContext _dbContext;

        public DataAccess(ArfBlocksDependencyProvider depencyProvider)
        {
            _dbContext = depencyProvider.GetInstance<ApplicationDbContext>();
        }

        public async Task<TodoTask> GetById(Guid id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(TodoTask task)
        {
            var completedTask = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == task.Id);

            _dbContext.Tasks.Update(completedTask);
            await _dbContext.SaveChangesAsync();
        }
    }
}