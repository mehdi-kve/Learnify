using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Learnify.Configuration.Dto;

namespace Learnify.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LearnifyAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
