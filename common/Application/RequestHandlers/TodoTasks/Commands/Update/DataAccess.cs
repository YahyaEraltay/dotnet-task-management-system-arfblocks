namespace Application.RequestHandlers.TodoTasks.Commands.Update
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
            var updatedTask = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == task.Id);
            
            _dbContext.Tasks.Update(updatedTask);
            await _dbContext.SaveChangesAsync();
        }
    }
}