namespace Station.Infrastructure.Services.TestServices;

public class TestDefinitions
{

    private static readonly Random _random = new Random();
    public static class Departments
    {
        public static Department DefaultDepartment() => new Department()
        {
            Name = $"Department {_random.Next(100, 999)}",
        };
    }

    public static class Users
    {
        public static User DefaultUser() => new User()
        {
            Email = $"john_doe{_random.Next(100,999)}@example.com",
            FirstName = "John",
            LastName = "Doe",
        };
    }

    public static class ToDoTasks
    {
        public static TodoTask DefaultTask(Guid departmentId) => new TodoTask()
        {
            Title = "",
            Description = "",
            AssignedDepartmentId = departmentId,
        };
    }

}