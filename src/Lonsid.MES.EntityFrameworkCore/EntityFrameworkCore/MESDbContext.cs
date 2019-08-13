using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lonsid.MES.EntityFrameworkCore
{
    public class MESDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public MESDbContext(DbContextOptions<MESDbContext> options) 
            : base(options)
        {

        }
    }
}
