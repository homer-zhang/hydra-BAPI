using Lonsid.MES.EntityFrameworkCore;

namespace Lonsid.MES.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly MESDbContext _context;

        public TestDataBuilder(MESDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}