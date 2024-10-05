using Domain.Base;

namespace Domain.Entities;

public class ApplicationDefinition : CoreEntity
{
    public Guid DefinedId { get; set; }
    public Guid DepartmentId { get; set; }
    public Guid UserId { get; set; }
    public Guid ToDoTaskId { get; set; }


}