namespace Application.RequestHandlers.Departments.Commands.Delete
{
    public class Mapper
    {
        public void MapToEntity(Department department, RequestModel payload)
        {
            department.IsDeleted = payload.IsDeleted;
        } 
        public ResponseModel MapToResponse(Department department)
        {
            return new ResponseModel()
            {
                Id = department.Id
            };
        }       
    }
}