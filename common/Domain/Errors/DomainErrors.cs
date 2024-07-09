namespace Domain.Errors
{
    public class DomainErrors
    {
        public class DepartmentErrors
        {
            public static string DepartmentNotExist { get; set; } = "";
        }

        public class UserErrors
        {
            public static string UserNotExist { get; set; } = "";
            public static string NameNotValid { get; set;} = "";
        }

        public class TodoTaskErrors
        {
            public static string TodoTaskNotExist { get; set;} = "";
        }
    }
}