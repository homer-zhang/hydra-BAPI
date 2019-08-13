using Lonsid.MES.Configuration;
using Lonsid.MES.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Lonsid.MES.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class MESDbContextFactory : IDesignTimeDbContextFactory<MESDbContext>
    {
        public MESDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MESDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(MESConsts.ConnectionStringName)
            );

            return new MESDbContext(builder.Options);
        }
    }
}