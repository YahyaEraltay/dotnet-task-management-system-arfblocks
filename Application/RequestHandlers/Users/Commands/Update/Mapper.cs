namespace Application.RequestHandlers.Users.Commands.Update
{
    public class Mapper
    {
        public User MapToEntity(RequestModel payload, User user)
        {
            user.Email = payload.Email;
            user.FirstName = payload.FirstName;
            user.LastName = payload.LastName;
            user.DepartmentId = payload.DepartmentId;

            return user;
        }

        public ResponseModel MapToResponse(User user)
        {
            return new ResponseModel()
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DepartmentId = user.Department.Id,
            };
        }
    }
}