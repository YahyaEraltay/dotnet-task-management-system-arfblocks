namespace Application.RequestHandlers.Departments.Commands.Delete;

public class ResponseModel : IResponseModel
{
    public Guid Id { get; set; }
}

public class RequestModel : IRequestModel
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
}