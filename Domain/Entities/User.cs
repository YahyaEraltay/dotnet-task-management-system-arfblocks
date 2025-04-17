namespace Domain.Entities;

public class User : BaseEntity
{
	public string Email { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }

	// Department Relation
	public Guid DepartmentId { get; set; }
	public Department Department { get; set; }
}