namespace Domain.Errors
{
    public class DomainErrors
    {
        public class CommonErrors
        {
            public static string NameNotValid { get; set; } = "";
            public static string IdNotValid { get; set; } = "";
        }

        public class DepartmentErrors
        {
            // Model Validations
            public static string DepartmentIdNotValid { get; set; } = "";
            public static string AssignedDepartmentIdNotValid { get; set; } = "";

            // Database Validations
            public static string DepartmentNotExist { get; set; } = "";

        }

        public class UserErrors
        {
            // Model Validations
            public static string UserIdNotValid { get; set; } = "";
            public static string EmailNotValid { get; set; } = "";
            public static string FirstNameNotValid { get; set; } = "";
            public static string LastNameNotValid { get; set; } = "";

            // Database Validations
            public static string UserNotExist { get; set; } = "";
        }

        public class TodoTaskErrors
        {
            // Model Validations
            public static string TodoTaskIdNotValid { get; set; } = "";
            public static string DescriptionNotValid { get; set; } = "";
            public static string TitleNotValid { get; set; } = "";

            // Database Validations
            public static string TodoTaskNotExist { get; set; } = "";
            public static string TaskStatusMustBePending { get; set; } = "";
            public static string UserDepartmentMustEqualToTaskAssignedDepartment { get; set; } = "";
            public static string UserMustBeTaskCreator { get; set; } = "";
        }
    }
}