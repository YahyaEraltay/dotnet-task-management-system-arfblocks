namespace Infrastructure.Services;

public class DefinitionService
{
    public static DateTime CreatedAt = new DateTime(2023, 7, 24, 10, 00, 00, 000, DateTimeKind.Local);
    public static int JwtExpirationAsHours = 24;
    public static int RftExpirationAsHours = 24;

    public static Guid DefaultId = Guid.Parse("28075253-B185-4DA5-E053-1F0DA8C0895C");
    public static Guid DefaultDepartmentId = Guid.Parse("749ADD34-DE67-C744-8D26-0A3E18499B36");
    public static Guid DefaultUserId = Guid.Parse("2BBD5E1E-FE3D-45C7-9E7F-BA0F2E798E1E");
    public static Guid DefaultToDoTaskId = Guid.Parse("2BBD5E1E-FE3D-45C7-9E7F-BA0F2E798E1E");


    public class Resources
    {
        public const string Departments = "Departments";
        public const string Users = "Users";
        public const string ToDoTasks = "ToDoTasks";

    }
}