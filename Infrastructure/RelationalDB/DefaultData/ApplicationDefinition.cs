
using Station.Infrastructure.Services;

namespace Infrastructure.RelationalDB.DefaultData;

public partial class DefaultData
{
    public static ApplicationDefinition ApplicationDefinition = new ApplicationDefinition()
    {
        Id = Guid.Parse("a19c901d-e8c2-4a1e-83aa-2162e05d568c"),
        DefinedId = DefinitionService.DefaultId,
        DepartmentId = DefinitionService.DefaultDepartmentId,
        ToDoTaskId= DefinitionService.DefaultToDoTaskId,
        UserId = DefinitionService.DefaultUserId,
        
    };

    public static List<ApplicationDefinition> DefaultApplicationDefinitions = new List<ApplicationDefinition>()
    {
        ApplicationDefinition,
    };
}