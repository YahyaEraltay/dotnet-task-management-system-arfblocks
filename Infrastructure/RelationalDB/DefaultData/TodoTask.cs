namespace Infrastructure.RelationalDB;

public partial class DefaultData
{
    public static TodoTask TodoTask = new TodoTask()
    {
        Id = DefinitionService.DefaultToDoTaskId,
        AssignedDepartmentId = DefinitionService.DefaultDepartmentId,
        CreatedById = DefinitionService.DefaultUserId,
        Description = "Test description",
        Title = "Test title",
        Status = TodoTaskStatus.Pending,
        StatusChangedAt = DefinitionService.CreatedAt,
        IsDeleted = false,
        CreatedAt = DefinitionService.CreatedAt,
    };

    public static List<TodoTask> DefaultTodoTasks = new List<TodoTask>()
        {
            TodoTask,
        };
}