namespace Infrastructure.Services;

public class CurrentTodoTaskModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid AssignedDepartmentId { get; set; }
    public string AssignedDepartmentName { get; set; }
    public Guid CreatedById { get; set; }
    public string CreatedByFirstName { get; set; }
    public string CreatedByLastName { get; set; }
    public TodoTaskStatus Status { get; set; }
    public DateTime StatusChangedAt { get; set; }
}