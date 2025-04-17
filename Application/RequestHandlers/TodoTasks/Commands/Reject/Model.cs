namespace Application.RequestHandlers.TodoTasks.Commands.Reject;

public class ResponseModel : IResponseModel
{
	public Guid Id { get; set; }
	public TodoTaskStatus Status { get; set; }
}

public class RequestModel : IRequestModel
{
	public Guid Id { get; set; }
	public string ActionComment { get; set; }
}