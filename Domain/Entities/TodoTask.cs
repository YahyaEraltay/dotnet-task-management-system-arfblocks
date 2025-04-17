using Domain.Base;

namespace Domain.Entities
{
    public class TodoTask : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TodoTaskStatus Status { get; set; }
        public DateTime StatusChangedAt { get; set; }

        public Guid AssignedDepartmentId { get; set; }
        public Department AssignedDepartment { get; set; }

        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; }
    }

    public enum TodoTaskStatus
    {
        Pending = 0,
        Completed = 1,
        Rejected = 2,
    }

}