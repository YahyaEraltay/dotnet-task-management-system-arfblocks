namespace Application.RequestHandlers.TodoTasks.Queries.Detail
{
	public class ResponseModel : IResponseModel
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public TodoTaskStatus Status { get; set; }
		public AssignedDepartmentResponseModel AssignedDepartment { get; set; }
		public UserResponseModel CreatedBy { get; set; }

		public class UserResponseModel
		{
			public Guid Id { get; set; }
			public string DisplayName { get; set; }
			public Guid DepartmentId { get; set; }
		}

		public class AssignedDepartmentResponseModel
		{
			public Guid Id { get; set; }
			public string Name { get; set; }
		}
	}

	public class RequestModel : IRequestModel
	{
		public Guid Id { get; set; }
	}

	
}