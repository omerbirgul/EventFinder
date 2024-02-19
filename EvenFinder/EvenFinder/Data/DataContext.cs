using Microsoft.EntityFrameworkCore;

namespace EvenFinder.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Event> Events => Set<Event>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Registration> Registrations => Set<Registration>();
        public DbSet<Comment> Comments => Set<Comment>();


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}
