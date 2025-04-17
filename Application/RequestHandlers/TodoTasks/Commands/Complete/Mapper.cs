namespace Application.RequestHandlers.TodoTasks.Commands.Complete;

public class Mapper
{
	public TodoTask MapToEntity(RequestModel payload, TodoTask task)
	{
		task.ActionComment = payload.ActionComment;
		task.StatusChangedAt = DateTime.Now;
		task.Status = TodoTaskStatus.Completed;
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