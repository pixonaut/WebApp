using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Webapp.Backend.Data;

namespace Webapp.backend.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Use same connection string as in appsettings.json
            var connectionString = "server=localhost;port=3306;database=webappdb;user=webappuser;password=webapppassword";

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}