
namespace Domain.Entites
{
    public class User 
    {
        public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		// Department Relation
		public Guid DepartmentId { get; set; }
		public Department Department { get; set; }
    }
}