using Abp.AutoMapper;
using Abp.BlobStoring;
using Abp.BlobStoring.FileSystem;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Learnify.Assignments;
using Learnify.Authorization;
using System.IO;

namespace Learnify
{
    [DependsOn(
        typeof(LearnifyCoreModule), 
        typeof(AbpAutoMapperModule),
        typeof(AbpBlobStoringModule),
        typeof(AbpBlobStoringFileSystemModule))]
    public class LearnifyApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<LearnifyAuthorizationProvider>();

            Configuration.Modules.AbpBlobStoring().Containers.Configure<AssignmentAppService>(container =>
            {
                container.UseFileSystem(config =>
                {
                    config.BasePath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "Blobs");
                });
            });

            // Add blob storage configuration
            Configuration.Modules.AbpBlobStoring().Containers.Configure.Configure(c =>
            {
                c.DefaultProvider = FileSystemBlobStoringProvider.Name;
                c.SetConfiguration("MyContainer", new BlobContainerConfiguration
                {
                    StoragePath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "App_Data",
                        "Blobs"
                    )
                });
            });

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
