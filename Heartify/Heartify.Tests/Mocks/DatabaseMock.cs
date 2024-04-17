using Heartify.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Heartify.Tests.Mocks
{
    public class DatabaseMock
    {
        public static HeartifyDbContext Instance 
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<HeartifyDbContext>()
                    .UseInMemoryDatabase("HeartifyTestingDatabase"
                        + DateTime.Now.Ticks.ToString())
                    .Options;

                return new HeartifyDbContext(dbContextOptions, false);
            }
        }
    }
}
