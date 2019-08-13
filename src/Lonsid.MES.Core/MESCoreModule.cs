using Abp.Modules;
using Abp.Reflection.Extensions;
using Lonsid.MES.Localization;

namespace Lonsid.MES
{
    public class MESCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            MESLocalizationConfigurer.Configure(Configuration.Localization);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MESCoreModule).GetAssembly());
        }
    }
}