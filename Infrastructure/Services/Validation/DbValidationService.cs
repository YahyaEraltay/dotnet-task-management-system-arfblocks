namespace Infrastructure.Services.Validation
{
    public class DbValidationService
    {
        private readonly ApplicationDbContext _dbContext;

        public DbValidationService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ValidateDepartmentExist(Guid departmentId)
        {
            var departmentExist = await _dbContext.Departments
                                                              .Where(x => !x.IsDeleted)
                                                              .AnyAsync(x => x.Id == departmentId);

            if (!departmentExist)
                throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.DepartmentErrors.DepartmentNotExist));
        }

        public async Task ValidateUserExist(Guid userId)
        {
            var userExist = await _dbContext.Users
                                                  .Where(x => !x.IsDeleted)
                                                  .AnyAsync(x => x.Id == userId);

            if (!userExist)
                throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.UserNotExist));
        }

        public async Task ValidateUserExist(string email)
		{
			// Get
			var userExist = await _dbContext.Users.AnyAsync(d => d.Email == email);

			// Check
			if (!userExist)
				throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.UserNotExist));
		}

        public async Task ValidateTodoTaskExist(Guid todoId)
        {
            var todoTaskExist = await _dbContext.Tasks
                                                      .Where(x => !x.IsDeleted)
                                                      .AnyAsync(x => x.Id == todoId);

            if (!todoTaskExist)
                throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.TodoTaskErrors.TodoTaskNotExist));
        }
    }
}