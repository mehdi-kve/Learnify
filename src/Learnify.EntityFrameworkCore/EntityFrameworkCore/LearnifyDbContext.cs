using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Learnify.Authorization.Roles;
using Learnify.Authorization.Users;
using Learnify.MultiTenancy;

namespace Learnify.EntityFrameworkCore
{
    public class LearnifyDbContext : AbpZeroDbContext<Tenant, Role, User, LearnifyDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public LearnifyDbContext(DbContextOptions<LearnifyDbContext> options)
            : base(options)
        {
        }
    }
}
