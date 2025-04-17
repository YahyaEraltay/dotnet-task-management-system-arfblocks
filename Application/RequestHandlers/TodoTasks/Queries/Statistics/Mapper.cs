namespace Application.RequestHandlers.TodoTasks.Queries.Statistics
{
	public class Mapper
	{
		public ResponseModel MapToResponse(int waitingForMyApprovalsCount, int myCreationsCount)
		{
			return new ResponseModel()
			{
				WaitingForMyApprovals = waitingForMyApprovalsCount,
				MyCreations = myCreationsCount
			};
		}
	}
}