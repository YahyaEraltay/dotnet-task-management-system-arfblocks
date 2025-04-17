namespace Application.RequestHandlers.Users.Commands.Delete;

public class Mapper
{
    public void MapToEntity(User user, RequestModel payload)
    {
        user.IsDeleted = payload.IsDeleted;
    }
    public ResponseModel MapToResponse(User user)
    {
        return new ResponseModel()
        {
            Id = user.Id
        };
    }
}