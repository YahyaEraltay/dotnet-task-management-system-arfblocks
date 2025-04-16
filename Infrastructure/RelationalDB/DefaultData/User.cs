namespace Infrastructure.RelationalDB
{
    public partial class DefaultData
    {
        public static Department Department = new Department()
        {
            Id = Guid.Parse("9f5502ee-c9e8-4fcc-aac6-668a84d799a7"),
            Name = "Test Department",
            IsDeleted = false,
            CreatedAt = DefinitionService.CreatedAt,
        };

        public static User User = new User()
        {
            Id = Guid.Parse("a1759505-2118-47f1-9f77-1a7b9c6a49c4"),
            Email = "admin@taskmanagementsystem.com",
            FirstName = "Admin",
            LastName = "User",
            DepartmentId = Department.Id,
            IsDeleted = false,
            CreatedAt = DefinitionService.CreatedAt,
        };

        public static TodoTask TodoTask = new TodoTask()
        {
            Id = Guid.Parse("a7f8ae2f-5adb-46b7-a6b9-cf2af668ff2c"),
            AssignedDepartmentId = Department.Id,
            CreatedById = User.Id,
            Description = "Test description",
            Title = "Test title",
            Status = TodoTaskStatus.Pending,
            StatusChangedAt = DateTime.Now,
            IsDeleted = false,
            CreatedAt = DefinitionService.CreatedAt,
        };

        public static List<Department> DefaultDepartments = new List<Department>()
        {
            Department,
        };

        public static List<User> DefaultUsers = new List<User>()
        {
            User,
        };

        public static List<TodoTask> DefaultTodoTasks = new List<TodoTask>()
        {
            TodoTask,
        };
    }
}