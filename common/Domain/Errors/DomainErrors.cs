namespace Domain.Errors
{
    public class DomainErrors
    {
        public class CommonErrors
        {
            public static string NameNotValid { get; set; } = "";
            public static string DepartmentIdNotValid { get; set; } = "";
            public static string UserIdNotValid { get; set; } = "";
            public static string TodoTaskIdNotValid { get; set; } = "";

        }

        public class DepartmentErrors
        {
            public static string DepartmentNotExist { get; set; } = "";

        }

        public class UserErrors
        {
            public static string UserNotExist { get; set; } = "";
        }

        public class TodoTaskErrors
        {
            public static string TodoTaskNotExist { get; set; } = "";
        }
    }
}