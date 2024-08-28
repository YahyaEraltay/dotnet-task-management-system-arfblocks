namespace Application.RequestHandlers.Users.Queries.Me
{
    public class ResponseModel : IResponseModel
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }

        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}