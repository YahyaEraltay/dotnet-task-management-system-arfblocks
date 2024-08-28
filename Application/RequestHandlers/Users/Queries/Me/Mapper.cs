namespace Application.RequestHandlers.Users.Queries.Me
{
	public class Mapper
	{
		public ResponseModel MapToResponseModel(User user)
		{
			return new ResponseModel()
			{
				UserId = user.Id,
				Email = user.Email,
				DisplayName = $"{user.FirstName} {user.LastName}",
				DepartmentId = user.DepartmentId,
                DepartmentName = user.Department.Name
			};
		}
	}
}