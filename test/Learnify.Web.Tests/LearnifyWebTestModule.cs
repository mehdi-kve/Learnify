using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Learnify.EntityFrameworkCore;
using Learnify.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Learnify.Web.Tests
{
    [DependsOn(
        typeof(LearnifyWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class LearnifyWebTestModule : AbpModule
    {
        public LearnifyWebTestModule(LearnifyEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LearnifyWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(LearnifyWebMvcModule).Assembly);
        }
    }
}