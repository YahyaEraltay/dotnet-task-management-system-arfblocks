namespace Application.RequestHandlers.Departments.Commands.Create
{
    public class ResponseModel : IResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class RequestModel : IRequestModel
    {
        public string Name { get; set; }
    }
}