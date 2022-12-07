using Dubai.Inventory.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Dubai.Inventory.UnitTest.Config;
public class MemoryDatabaseTestConfig
{
    protected MemoryDatabaseTestConfig()
    {
        if (Context != null) return;

        Context = CreateContext();

        new ProductInitialize().Initialize(Context);
    }

    protected ApplicationDbContext Context { get; }

    private ApplicationDbContext CreateContext()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "MasterDBTest")
           .Options;

        return new ApplicationDbContext(options);
    }

}
