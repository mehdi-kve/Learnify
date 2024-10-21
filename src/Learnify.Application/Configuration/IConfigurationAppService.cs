using System.Threading.Tasks;
using Learnify.Configuration.Dto;

namespace Learnify.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
