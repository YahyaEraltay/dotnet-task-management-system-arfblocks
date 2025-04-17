namespace Application.RequestHandlers.Users.Commands.Create;

public class Mapper
{
    public User MapToNewEntity(RequestModel payload)
    {
        return new User
        {
            Email = payload.Email,
            FirstName = payload.FirstName,
            LastName = payload.LastName,
            DepartmentId = payload.DepartmentId
        };
    }

    public ResponseModel MapToResponse(User user)
    {
        return new ResponseModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName
        };
    }
}