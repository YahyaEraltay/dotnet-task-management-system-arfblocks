namespace Application.RequestHandlers.Users.Queries.All
{
	public class ResponseModel : IResponseModel<Array>
	{
		public Guid Id { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string DisplayName { get; set; }

		public Guid DepartmentId { get; set; }
		public string DepartmentName { get; set; }
	}

	public class RequestModel : IRequestModel
	{
		public XSorting Sorting { get; set; }
		public List<XFilterItem> Filters { get; set; }
		public XPageRequest PageRequest { get; set; }
	}
}