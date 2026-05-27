using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SuperJero_Api.Data
{
    public class DatabaseDesignTimeFactory : IDesignTimeDbContextFactory<Database>
    {
        public Database CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Database>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=SuperHeroDb;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;MultipleActiveResultSets=true");

            return new Database(optionsBuilder.Options);
        }
    }
}