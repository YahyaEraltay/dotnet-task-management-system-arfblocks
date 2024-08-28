namespace Application.RequestHandlers.TodoTasks.Queries.Detail
{
	public class Mapper
	{
		public ResponseModel MapToResponse(TodoTask task)
		{
			return new ResponseModel()
			{
				Id = task.Id,
				Title = task.Title,
				Description = task.Description,
				Status = task.Status,
				AssignedDepartment = new ResponseModel.AssignedDepartmentResponseModel()
				{
					Id = task.AssignedDepartment.Id,
					Name = task.AssignedDepartment.Name,
				},
				CreatedBy = new ResponseModel.UserResponseModel()
				{
					Id = task.CreatedBy.Id,
					DisplayName = $"{task.CreatedBy.FirstName} {task.CreatedBy.LastName}",
					DepartmentId = task.CreatedBy.DepartmentId,
				},
			};
		}
	}
}