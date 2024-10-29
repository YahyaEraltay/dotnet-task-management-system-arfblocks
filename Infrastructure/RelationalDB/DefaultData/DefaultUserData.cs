namespace Infrastructure.RelationalDB;

public partial class DefaultUserData
{
    public static User AdminUser = new User()
    {
        Id = Guid.Parse("a1759505-2118-47f1-9f77-1a7b9c6a49c4"),
        Email = "admin@tarpet.com",
        FirstName = "Admin",
        LastName = "User",
        DepartmentId = Guid.Parse("7c89a378-c1ed-4eac-8cb7-336d11943b78"),
        IsDeleted = false,
        CreatedAt = DefinitionService.CreatedAt,
    };

    public static List<User> DefaultUsers = new List<User>()
    {
        AdminUser,
    };
}