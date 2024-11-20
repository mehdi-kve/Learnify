using Abp.AutoMapper;
using Abp.BlobStoring;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Learnify.Authorization;

namespace Learnify
{
    [DependsOn(
        typeof(LearnifyCoreModule), 
        typeof(AbpAutoMapperModule),
        typeof(AbpBlobStoringModule))]
    public class LearnifyApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<LearnifyAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(LearnifyApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
