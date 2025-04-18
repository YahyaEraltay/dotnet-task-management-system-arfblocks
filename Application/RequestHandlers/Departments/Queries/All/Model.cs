namespace Application.RequestHandlers.Departments.Queries.All;

public class ResponseModel : IResponseModel<Array>
{
	public Guid Id { get; set; }
	public string Name { get; set; }
}

public class RequestModel : IRequestModel
{
	public XSorting Sorting { get; set; }
	public List<XFilterItem> Filters { get; set; }
	public XPageRequest PageRequest { get; set; }
}