namespace Application.RequestHandlers.Users.Queries.Detail
{
    public class ResponseModel : IResponseModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }

    public class RequestModel : IRequestModel
    {
        public Guid Id { get; set; }
    }
}