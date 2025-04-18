namespace Application.RequestHandlers.TodoTasks.Queries.UIDC;

public class ResponseModel : IResponseModel
{
    public Guid Id { get; set; }
    public UidcCommands Commands { get; set; }

    public class UidcCommands
    {
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool UnDelete { get; set; }
        public bool Reject { get; set; }
        public bool Complete { get; set; }
    }
}

public class RequestModel : IRequestModel
{
    public Guid Id { get; set; }
}