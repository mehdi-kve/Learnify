using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Learnify.Authorization
{
    public class LearnifyAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            // Add permissions for the "Student" role  
            context.CreatePermission(PermissionNames.Page_Student, L("Student"));
            context.CreatePermission(PermissionNames.Pages_Student_ViewStudentPage, L("ViewStudentPage"));
            context.CreatePermission(PermissionNames.Pages_Student_EditStudentPage, L("EditStudentPage"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LearnifyConsts.LocalizationSourceName);
        }
    }
}
