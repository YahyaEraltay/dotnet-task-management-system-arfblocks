namespace Cmms.Infrastructure.Services;

public class CurrentUserModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid DepartmentId { get; set; }

}