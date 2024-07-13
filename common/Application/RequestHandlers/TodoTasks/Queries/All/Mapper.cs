namespace Application.RequestHandlers.TodoTasks.Queries.All
{
    public class Mapper
    {
        public List<ResponseModel> MapToResponse(List<TodoTask> tasks)
        {
            return tasks?.Select(task => new ResponseModel
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
                    DisplayName = $"{task.CreatedBy.FirstName} {task.CreatedBy.LastName}"
                }
            }).ToList();
        }
    }
}