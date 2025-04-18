namespace Application.RequestHandlers.Apps.Queries.UISC;

public class ResponseModel : IResponseModel
{
    public Guid UserId { get; set; }
    public UISC Uisc { get; set; }

    public class UISC
    {
        public Pages Pages { get; set; }
    }

    public class Pages
    {
        public bool Statistics { get; set; }

        public bool ListTodoTasks { get; set; }
        public bool ListMyTasks { get; set; }
        public bool ListPendings { get; set; }
        public bool ListDepartments { get; set; }
        public bool ListUsers { get; set; }
    }
}

public class RequestModel : IRequestModel
{ }