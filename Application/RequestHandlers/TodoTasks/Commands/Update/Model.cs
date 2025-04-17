namespace Application.RequestHandlers.TodoTasks.Commands.Update;

public class ResponseModel : IResponseModel
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public Guid AssignedDepartmentId { get; set; }
	public Guid CreatedById { get; set; }
	public TodoTaskStatus Status { get; set; }
}

public class RequestModel : IRequestModel
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public Guid AssignedDepartmentId { get; set; }
}