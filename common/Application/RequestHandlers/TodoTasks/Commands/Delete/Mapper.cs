namespace Application.RequestHandlers.TodoTasks.Commands.Delete
{
    public class Mapper
    {
        public void MapToEntity(TodoTask task, RequestModel payload)
        {
            task.IsDeleted = payload.IsDeleted;
        } 
        public ResponseModel MapToResponse(TodoTask task)
        {
            return new ResponseModel()
            {
                Id = task.Id
            };
        }       
    }
}