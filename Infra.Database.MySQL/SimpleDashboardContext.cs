using Microsoft.EntityFrameworkCore;

namespace Infra.Database.MySQL
{
    public class SimpleDashboardContext : DbContext
    {
        public SimpleDashboardContext(DbContextOptions options) : base(options)
        {
        }
    }
}
