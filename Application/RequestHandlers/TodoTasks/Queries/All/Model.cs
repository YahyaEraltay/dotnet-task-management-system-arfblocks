namespace Application.RequestHandlers.TodoTasks.Queries.All;

public class ResponseModel : IResponseModel<Array>
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
	}

	public class AssignedDepartmentResponseModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
	}
}

public class RequestModel : IRequestModel
{
	public XSorting Sorting { get; set; }
	public List<XFilterItem> Filters { get; set; }
	public XPageRequest PageRequest { get; set; }
}