
using Station.Infrastructure.Services;

namespace Infrastructure.RelationalDB.DefaultData;

public partial class DefaultData
{
    public static ApplicationDefinition ApplicationDefinition = new ApplicationDefinition()
    {
        Id = Guid.Parse("a19c901d-e8c2-4a1e-83aa-2162e05d568c"),
        De = DefinitionService.DefaultDepartmentId,
        StationLicenseNo = DevDefaultData.DefaultStationLicenseNo,
        StationSubLicenseNo = DevDefaultData.DefaultStationSubLicenseNo,
        InstalledAt = DefinitionService.CreatedAt,
    };

    public static List<ApplicationDefinition> DefaultApplicationDefinitions = new List<ApplicationDefinition>()
    {
        ApplicationDefinition,
    };
}