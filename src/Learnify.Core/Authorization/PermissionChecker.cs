using Abp.Authorization;
using Learnify.Authorization.Roles;
using Learnify.Authorization.Users;

namespace Learnify.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
