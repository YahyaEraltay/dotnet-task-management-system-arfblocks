namespace Infrastructure.RelationalDB;

public static class DefaultDataSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasData(DefaultData.DefaultDepartments);
        modelBuilder.Entity<User>().HasData(DefaultData.DefaultUsers);
        modelBuilder.Entity<TodoTask>().HasData(DefaultData.DefaultTodoTasks);
    }
}