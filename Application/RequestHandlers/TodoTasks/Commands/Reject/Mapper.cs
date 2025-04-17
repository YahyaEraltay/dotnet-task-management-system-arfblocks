namespace Application.RequestHandlers.TodoTasks.Commands.Reject;

public class Mapper
{
	public TodoTask MapToEntity(TodoTask task)
	{
		task.StatusChangedAt = DateTime.Now;
		task.Status = TodoTaskStatus.Rejected;
		return task;
	}
	public ResponseModel MapToResponse(TodoTask task)
	{
		return new ResponseModel()
		{
			Id = task.Id,
			Status = task.Status,
		};
	}
}