using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Learnify.MultiTenancy;

namespace Learnify.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
