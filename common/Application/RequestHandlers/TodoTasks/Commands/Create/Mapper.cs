namespace Application.RequestHandlers.TodoTasks.Commands.Create
{
	public class Mapper
	{
		public TodoTask MapToNewEntity(RequestModel payload, Guid currentClientId)
		{
			return new TodoTask()
			{
				Title = payload.Title,
				Description = payload.Description,
				AssignedDepartmentId = payload.AssignedDepartmentId,
				CreatedById = currentClientId,
				Status = TodoTaskStatus.Pending,
				StatusChangedAt = DateTime.UtcNow
			};
		}

		public ResponseModel MapToNewResponseModel(TodoTask task)
		{
			return new ResponseModel()
			{
				Id = task.Id,
				Title = task.Title,
				Description = task.Description,
				AssignedDepartmentId = task.AssignedDepartmentId,
				CreatedById = task.CreatedById,
				Status = task.Status,
			};
		}
	}
}