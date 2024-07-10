namespace Application.RequestHandlers.Departments.Queries.Detail
{
    public class Mapper
    {
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