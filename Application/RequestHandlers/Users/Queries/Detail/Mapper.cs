namespace Application.RequestHandlers.Users.Queries.Detail;

public class Mapper
{
    public ResponseModel MapToResponse(User user)
    {
        return new ResponseModel
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            DepartmentId = user.Department.Id,
            DepartmentName = user.Department.Name,
        };
    }
}