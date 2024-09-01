namespace Infrastructure.Services.TestServices;

public class TestDefinitions
{

    private static readonly Random _random = new Random();
    public static class Departments
    {
        public static Department DefaultDepartment(Guid id) => new Department()
        {
            Id = id,
            Name = $"Department {_random.Next(100, 999)}",
        };
    }

    public static class Users
    {
        public static User DefaultUser(Guid id) => new User()
        {
            Id = id,
            Email = $"john_doe{_random.Next(100,999)}@example.com",
            FirstName = "John",
            LastName = "Doe",
        };
    }

    public static class ToDoTasks
    {
        public static TodoTask DefaultTask(Guid id, Guid departmentId) => new TodoTask()
        {
            Id = id,
            Title = "Sample Task",
            Description = "Task Description",
            AssignedDepartmentId = departmentId,
        };
    }
}