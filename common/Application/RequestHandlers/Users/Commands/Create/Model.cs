namespace Application.RequestHandlers.Users.Commands.Create
{
    public class ResponseModel : IResponseModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class RequestModel : IRequestModel
    {
        public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

        public Guid DepartmentId { get; set; }
    }
}