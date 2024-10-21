using System.Threading.Tasks;
using Abp.Application.Services;
using Learnify.Authorization.Accounts.Dto;

namespace Learnify.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
