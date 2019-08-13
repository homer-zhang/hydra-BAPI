using System;
using System.Threading.Tasks;
using Abp.TestBase;
using Lonsid.MES.EntityFrameworkCore;
using Lonsid.MES.Tests.TestDatas;

namespace Lonsid.MES.Tests
{
    public class MESTestBase : AbpIntegratedTestBase<MESTestModule>
    {
        public MESTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<MESDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<MESDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<MESDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<MESDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<MESDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<MESDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<MESDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<MESDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
