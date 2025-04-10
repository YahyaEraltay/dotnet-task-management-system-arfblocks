namespace Infrastructure.Services;

public class CurrentUserModel
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public Guid DepartmentId { get; set; }

}