using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Learnify.Configuration;

namespace Learnify.Web.Host.Startup
{
    [DependsOn(
       typeof(LearnifyWebCoreModule))]
    public class LearnifyWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LearnifyWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LearnifyWebHostModule).GetAssembly());
        }
    }
}
