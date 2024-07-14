namespace Application.RequestHandlers.TodoTasks.Commands.Complete
{
	public class Mapper
	{
        public TodoTask MapToEntity (TodoTask task)
        {
            task.StatusChangedAt = DateTime.Now;
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
}