namespace Infrastructure.RelationalDB
{
    public partial class DefaultData
    {
        public static User User = new User()
        {
            Id = DefinitionService.DefaultUserId,
            Email = "admin@taskmanagementsystem.com",
            FirstName = "Admin",
            LastName = "User",
            DepartmentId = DefinitionService.DefaultDepartmentId,
            IsDeleted = false,
            CreatedAt = DefinitionService.CreatedAt,
        };


        public static List<User> DefaultUsers = new List<User>()
        {
            User,
        };
    }
}