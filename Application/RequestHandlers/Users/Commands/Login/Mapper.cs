namespace Application.RequestHandlers.Users.Commands.Login;

public class Mapper
{
	public ResponseModel MapToResponse(User user, string jwtToken)
	{
		return new ResponseModel()
		{
			JwtToken = jwtToken,
			UserId = user.Id,
			Email = user.Email,
			DisplayName = $"{user.FirstName} {user.LastName}",
			Department = new ResponseModel.DepartmentResponseModel()
			{
				Id = user.Department.Id,
				Name = user.Department.Name,
			}
		};
	}
}