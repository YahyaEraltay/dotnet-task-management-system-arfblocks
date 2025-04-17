namespace Application.RequestHandlers.Departments.Commands.Update;

public class Mapper
{
    public Department MapToEntity(RequestModel payload, Department department)
    {
        department.Name = payload.Name;

        return department;
    }

    public ResponseModel MapToResponse(Department department)
    {
        return new ResponseModel()
        {
            Id = department.Id,
            Name = department.Name
        };
    }
}