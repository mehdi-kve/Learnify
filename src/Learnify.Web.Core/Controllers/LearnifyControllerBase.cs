using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Learnify.Controllers
{
    public abstract class LearnifyControllerBase: AbpController
    {
        protected LearnifyControllerBase()
        {
            LocalizationSourceName = LearnifyConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
