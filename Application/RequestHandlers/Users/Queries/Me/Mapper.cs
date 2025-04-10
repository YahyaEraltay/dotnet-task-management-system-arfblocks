namespace Application.RequestHandlers.Users.Queries.Me
{
	public class Mapper
	{
		public ResponseModel MapToResponse(User user)
		{
			return new ResponseModel()
			{
				Id = user.Id,
				Email = user.Email,
				DisplayName = $"{user.FirstName} {user.LastName}",
				DepartmentId = user.DepartmentId,
				DepartmentName = user.Department.Name
			};
		}
	}
}