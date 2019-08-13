using Abp.AspNetCore.Mvc.Controllers;

namespace Lonsid.MES.Web.Controllers
{
    public abstract class MESControllerBase: AbpController
    {
        protected MESControllerBase()
        {
            LocalizationSourceName = MESConsts.LocalizationSourceName;
        }
    }
}