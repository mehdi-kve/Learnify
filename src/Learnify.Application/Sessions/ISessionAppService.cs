using System.Threading.Tasks;
using Abp.Application.Services;
using Learnify.Sessions.Dto;

namespace Learnify.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
