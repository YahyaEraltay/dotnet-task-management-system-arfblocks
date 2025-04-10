namespace Infrastructure.Services;

public class CurrentUserModel
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Guid DepartmentId { get; set; }
    public string DepartmentName { get; set; }
    public string Email { get; set; }
}