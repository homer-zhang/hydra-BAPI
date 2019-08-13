using Abp.AspNetCore.Mvc.Views;

namespace Lonsid.MES.Web.Views
{
    public abstract class MESRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected MESRazorPage()
        {
            LocalizationSourceName = MESConsts.LocalizationSourceName;
        }
    }
}
