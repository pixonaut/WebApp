using Microsoft.EntityFrameworkCore;

namespace Webapp.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // Example: Users table
        public DbSet<User> Users { get; set; }
    }

    // Example entity
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}