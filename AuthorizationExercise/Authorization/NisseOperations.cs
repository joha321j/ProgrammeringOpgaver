using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace AuthorizationExercise.Data
{
    public class NisseOperations
    {
        public static OperationAuthorizationRequirement Create =
            new OperationAuthorizationRequirement { Name = NisseConstants.CreateOperationName };
        public static OperationAuthorizationRequirement Read =
            new OperationAuthorizationRequirement { Name = NisseConstants.ReadOperationName };
        public static OperationAuthorizationRequirement Update =
            new OperationAuthorizationRequirement { Name = NisseConstants.UpdateOperationName };
        public static OperationAuthorizationRequirement Delete =
            new OperationAuthorizationRequirement { Name = NisseConstants.DeleteOperationName };
    }

    public class NisseConstants
    {
        public static readonly string CreateOperationName = "Create";
        public static readonly string ReadOperationName = "Read";
        public static readonly string UpdateOperationName = "Update";
        public static readonly string DeleteOperationName = "Delete";

        public static readonly string AdministratorNisse = "AdministratorNisse";
        public static readonly string ModeratorNisse = "ModeratorNisse";
        public static readonly string NoobNisse = "NoobNisse";
    }
}
