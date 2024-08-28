namespace Application.RequestHandlers.Users.Queries.All
{
    public class Mapper
    {
        public List<ResponseModel> MapToResponse(List<User> users)
        {
            return users?.Select(user => new ResponseModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DisplayName = $"{user.FirstName} {user.LastName}",
                DepartmentId = user.DepartmentId,
                DepartmentName = user.Department.Name
            }).ToList();
        }
    }
}