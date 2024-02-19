using Microsoft.EntityFrameworkCore;

namespace EvenFinder.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Event> Events => Set<Event>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Registration> Registrations => Set<Registration>();


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}
