using Microsoft.EntityFrameworkCore;
namespace Tracking
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }
        public DbSet<Location> Locations { get; set; }
       
    }
}
