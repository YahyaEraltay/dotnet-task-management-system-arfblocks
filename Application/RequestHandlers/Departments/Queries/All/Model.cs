namespace Application.RequestHandlers.Departments.Queries.All
{
	public class ResponseModel : IResponseModel<Array>
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
	}

	public class RequestModel : IRequestModel
	{
	}
}