namespace Infrastructure.Services.TestServices;

public class TestDefinitions
{

    private static readonly Random _random = new Random();
    public static class Departments
    {
        public static Department DefaultDepartment() => new Department()
        {
            Id = Guid.Parse("31500f70-b1fb-4b40-a4bb-c35c8df10159"),
            Name = $"Department {_random.Next(100, 999)}",
        };
    }

    public static class Users
    {
        public static User DefaultUser(Guid id) => new User()
        {
            Id = Guid.Parse("42596b50-6302-4019-a506-616f06f87d10"),
            Email = $"john_doe{_random.Next(100, 999)}@example.com",
            FirstName = "John",
            LastName = "Doe",
        };
    }

    public static class ToDoTasks
    {
        public static TodoTask DefaultTask(Guid id, Guid departmentId) => new TodoTask()
        {
            Id = Guid.Parse("e082c826-4375-4f2a-bf72-f0df8e018426"),
            Title = "Sample Task",
            Description = "Task Description",
            AssignedDepartmentId = departmentId,
        };
    }
}