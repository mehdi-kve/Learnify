using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Learnify.EntityFrameworkCore
{
    public static class LearnifyDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LearnifyDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LearnifyDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
