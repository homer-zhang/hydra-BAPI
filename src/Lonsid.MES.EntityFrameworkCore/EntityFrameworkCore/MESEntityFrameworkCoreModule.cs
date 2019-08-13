using Abp.EntityFrameworkCore;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Lonsid.MES.EntityFrameworkCore
{
    [DependsOn(
        typeof(MESCoreModule), 
        typeof(AbpEntityFrameworkCoreModule))]
    public class MESEntityFrameworkCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MESEntityFrameworkCoreModule).GetAssembly());
        }
    }
}