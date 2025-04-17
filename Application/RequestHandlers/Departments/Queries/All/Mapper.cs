namespace Application.RequestHandlers.Departments.Queries.All;

public class Mapper
{
    public List<ResponseModel> MapToResponse(List<Department> departments)
    {
        return departments?.Select(department => new ResponseModel
        {
            Id = department.Id,
            Name = department.Name
        }).ToList();
    }
}