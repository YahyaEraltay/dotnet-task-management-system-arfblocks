
namespace Application.RequestHandlers.Departments.Commands.Create
{
    public class Mapper
    {
        public Department MapToNewEntity(RequestModel payload)
        {
            return new Department
            {
                Name = payload.Name
            };
        }

        public ResponseModel MapToResponse(Department department)
        {
            return new ResponseModel
            {
                Id = department.Id,
                Name = department.Name
            };
        }
    }
}