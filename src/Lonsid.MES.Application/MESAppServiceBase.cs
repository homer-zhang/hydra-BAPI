using Abp.Application.Services;

namespace Lonsid.MES
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class MESAppServiceBase : ApplicationService
    {
        protected MESAppServiceBase()
        {
            LocalizationSourceName = MESConsts.LocalizationSourceName;
        }
    }
}