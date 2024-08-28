namespace Application.RequestHandlers.Users.Commands.Login
{
    public class ResponseModel : IResponseModel
    {
        public string JwtToken { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public DepartmentResponseModel Department { get; set; }

        public class DepartmentResponseModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }

    public class RequestModel : IRequestModel
    {
        public string Email { get; set; }
    }
}