namespace Infrastructure.RelationalDB;

public partial class ApplicationDefinition
{
    public static Domain.Entities.ApplicationDefinition ApplicationDefinitions = new Domain.Entities.ApplicationDefinition()
    {
        Id = Guid.Parse("a19c901d-e8c2-4a1e-83aa-2162e05d568c"),
        DefinedId = DefinitionService.DefaultId,
        DepartmentId = DefinitionService.DefaultDepartmentId,
        ToDoTaskId = DefinitionService.DefaultToDoTaskId,
        UserId = DefinitionService.DefaultUserId,

    };

    public static List<Domain.Entities.ApplicationDefinition> DefaultApplicationDefinitions = new List<Domain.Entities.ApplicationDefinition>()
    {
        ApplicationDefinitions,
    };
}