namespace Infrastructure.RelationalDB
{
    public partial class DefaultData
    {
        public static Department Department = new Department()
        {
            Id = DefinitionService.DefaultDepartmentId,
            Name = "Test Department",
            IsDeleted = false,
            CreatedAt = DefinitionService.CreatedAt,
        };

        public static List<Department> DefaultDepartments = new List<Department>()
        {
            Department,
        };
    }
}