namespace Application.RequestHandlers.TodoTasks.Commands.Update
{
	public class Mapper
	{
		public TodoTask MapToEntity(RequestModel payload, TodoTask task)
		{
			task.Title = payload.Title;
			task.Description = payload.Description;
			task.AssignedDepartmentId = payload.AssignedDepartmentId;

			return task;
		}

		public ResponseModel MapToResponse(TodoTask task)
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