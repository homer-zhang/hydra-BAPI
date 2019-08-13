using Microsoft.EntityFrameworkCore;

namespace Lonsid.MES.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<MESDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for MESDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
