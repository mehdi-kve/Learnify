using Abp.Application.Services;
using Learnify.MultiTenancy.Dto;

namespace Learnify.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

