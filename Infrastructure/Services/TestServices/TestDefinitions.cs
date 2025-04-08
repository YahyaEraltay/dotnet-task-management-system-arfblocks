namespace Infrastructure.Services.TestServices;

public class TestDefinitions
{

    public static class Departments
    {
        public static Department DefaultDepartment() => new Department()
        {
            Name = $"Department {new Random().Next(100, 999)}",
        };
    }

    public static class Users
    {
        public static User DefaultUser(Guid id) => new User()
        {
            Email = $"john_doe{new Random().Next(100, 999)}@example.com",
            FirstName = "John",
            LastName = "Doe",
        };
    }

    public static class ToDoTasks
    {
        public static TodoTask DefaultTask(Guid id, Guid departmentId) => new TodoTask()
        {
            Title = "Sample Task",
            Description = "Task Description",
            AssignedDepartmentId = departmentId,
        };
    }
}