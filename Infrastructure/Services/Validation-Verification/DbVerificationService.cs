namespace Infrastructure.Services;

public class DbVerificationService
{
    private readonly ApplicationDbContext _dbContext;

    public DbVerificationService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////WEBAPI//////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*--------------------------------------------------------------TodoTask---------------------------------------------------------------*/
    public async Task VerifyTaskStatusIsPending(Guid taskId)
    {
        var todoTask = await _dbContext.Tasks.Where(x => x.Id == taskId).FirstOrDefaultAsync();

        if (todoTask.Status != TodoTaskStatus.Pending)
            throw new ArfBlocksVerificationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.TodoTaskErrors.TaskStatusMustBePending));
    }

    public async Task VerifyUserDepartmentEqualsTaskAssignedDepartment(Guid taskId, Guid userId)
    {
        var todoTaskDepartmentId = await _dbContext.Tasks.Where(x => x.Id == taskId).Select(y => y.AssignedDepartmentId).FirstOrDefaultAsync();
        var userDepartmentId = await _dbContext.Users.Where(x => x.Id == userId).Select(y => y.DepartmentId).FirstOrDefaultAsync();

        if (todoTaskDepartmentId != userDepartmentId)
            throw new ArfBlocksVerificationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.TodoTaskErrors.UserDepartmentMustEqualToTaskAssignedDepartment));
    }

    public async Task VerifyUserIsTaskOwner(Guid taskId, Guid userId)
    {
        var todoTaskCreatedById = await _dbContext.Tasks.Where(x => x.Id == taskId).Select(y => y.CreatedById).FirstOrDefaultAsync();
        var user = await _dbContext.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();

        if (todoTaskCreatedById != user.Id)
            throw new ArfBlocksVerificationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.TodoTaskErrors.UserMustBeTaskCreator));
    }
}