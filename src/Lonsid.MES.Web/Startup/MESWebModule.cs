using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Lonsid.MES.Configuration;
using Lonsid.MES.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Lonsid.MES.Web.Startup
{
    [DependsOn(
        typeof(MESApplicationModule), 
        typeof(MESEntityFrameworkCoreModule), 
        typeof(AbpAspNetCoreModule))]
    public class MESWebModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public MESWebModule(IHostingEnvironment env)
        {
            _appConfiguration = AppConfigurations.Get(env.ContentRootPath, env.EnvironmentName);
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(MESConsts.ConnectionStringName);

            Configuration.Navigation.Providers.Add<MESNavigationProvider>();

            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(
                    typeof(MESApplicationModule).GetAssembly()
                );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MESWebModule).GetAssembly());
        }
    }
}