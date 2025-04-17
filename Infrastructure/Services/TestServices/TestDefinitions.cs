namespace Infrastructure.Services.TestServices;

public class TestDefinitions
{

    public static class Actors
    {

        public static CurrentUserModel CurrentUser = new CurrentUserModel()
        {
            Id = DefaultData.User.Id,
            FirstName = DefaultData.User.FirstName,
            LastName = DefaultData.User.LastName,
            DepartmentId = DefaultData.User.DepartmentId,
            DepartmentName = DefaultData.User.Department.Name,
            Email = DefaultData.User.Email,
        };

        public static CurrentTodoTaskModel CurrentTodoTask = new CurrentTodoTaskModel()
        {
            Id = DefaultData.TodoTask.Id,
            Title = DefaultData.TodoTask.Title,
            Description = DefaultData.TodoTask.Description,
            AssignedDepartmentId = DefaultData.TodoTask.AssignedDepartmentId,
            AssignedDepartmentName = DefaultData.TodoTask.AssignedDepartment.Name,
            CreatedById = DefaultData.TodoTask.CreatedById,
            CreatedByFirstName = DefaultData.TodoTask.CreatedBy.FirstName,
            CreatedByLastName = DefaultData.TodoTask.CreatedBy.LastName,
            Status = DefaultData.TodoTask.Status,
            StatusChangedAt = DefaultData.TodoTask.StatusChangedAt,
        };
    }

    public static class Departments
    {
        public static Department DefaultDepartment() => new Department()
        {
            Name = $"Department {new Random().Next(100, 999)}",
        };
    }

    public static class Users
    {
        public static User DefaultUser(Guid departmentId) => new User()
        {
            Email = $"john_doe{new Random().Next(100, 999)}@example.com",
            FirstName = $"John {new Random().Next(100, 999)}",
            LastName = $"Doe {new Random().Next(100, 999)}",
            DepartmentId = departmentId,
        };
    }

    public static class ToDoTasks
    {
        public static TodoTask DefaultTask(Guid createdById, Guid departmentId, TodoTaskStatus todoTaskStatus) => new TodoTask()
        {
            Title = $"Sample Task {new Random().Next(100, 999)}",
            Description = $"Task Description {new Random().Next(100, 999)}",
            AssignedDepartmentId = departmentId,
            CreatedById = createdById,
            Status = todoTaskStatus,
            ActionComment = $"Action Comment {new Random().Next(100, 999)}",
            IsDeleted = false,
            StatusChangedAt = DateTime.Now,
        };
    }
}