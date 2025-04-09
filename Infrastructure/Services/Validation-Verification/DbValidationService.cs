namespace Cmms.Infrastructure.Services;

public class DbValidationService
{
    private readonly ApplicationDbContext _dbContext;

    public DbValidationService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////WEBAPI//////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /*---------------------------------------------------------------Department---------------------------------------------------------------*/
    public async Task ValidateDepartmentExist(Guid departmentId)
    {
        var isDepartmentExist = await _dbContext.Departments.AnyAsync(u => u.Id == departmentId);

        if (!isDepartmentExist)
            throw new ArfBlocksVerificationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.DepartmentErrors.DepartmentNotExist));
    }

    /*---------------------------------------------------------------User---------------------------------------------------------------*/
    public async Task ValidateUserExistById(Guid userId)
    {
        var isUserExist = await _dbContext.Users.AnyAsync(a => a.Id == userId);

        // Check
        if (!isUserExist)
            throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.UserNotExist));
    }

    public async Task ValidateUserExistByEmail(string email)
    {
        var isUserExist = await _dbContext.Users.AnyAsync(a => a.Email == email);

        // Check
        if (!isUserExist)
            throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.UserNotExist));
    }

    /*---------------------------------------------------------------TodoTask---------------------------------------------------------------*/
    public async Task ValidateTodoTaskExist(Guid taskId)
    {
        var isTodoTaskExist = await _dbContext.Tasks.AnyAsync(a => a.Id == taskId);

        // Check
        if (!isTodoTaskExist)
            throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.TodoTaskErrors.TodoTaskNotExist));
    }
}