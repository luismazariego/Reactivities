using Microsoft.EntityFrameworkCore;
using Reactivities.Reactivities.Domain;

namespace Reactivities.Reactivities.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {            
        }

        public DbSet<Activity> Activities { get; set; }
    }
}