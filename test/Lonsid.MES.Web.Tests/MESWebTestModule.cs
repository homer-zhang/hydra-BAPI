using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Lonsid.MES.Web.Startup;
namespace Lonsid.MES.Web.Tests
{
    [DependsOn(
        typeof(MESWebModule),
        typeof(AbpAspNetCoreTestBaseModule)
        )]
    public class MESWebTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MESWebTestModule).GetAssembly());
        }
    }
}