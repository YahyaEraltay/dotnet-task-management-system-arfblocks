namespace Application.RequestHandlers.TodoTasks.Queries.Statistics;

public class ResponseModel : IResponseModel
{
	public int WaitingForMyApprovals { get; set; }
	public int MyCreations { get; set; }

}

public class RequestModel : IRequestModel
{
}

