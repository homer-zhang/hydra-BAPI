using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Lonsid.MES
{
    [DependsOn(
        typeof(MESCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MESApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MESApplicationModule).GetAssembly());
        }
    }
}