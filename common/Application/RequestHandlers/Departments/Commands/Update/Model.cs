namespace Application.RequestHandlers.Departments.Commands.Update
{
    public class ResponseModel : IResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class RequestModel : IRequestModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}