using Microsoft.EntityFrameworkCore;

namespace MvcApplicationForCV.Models
{
    public class MvcApplicationForCvDbContext : DbContext
    {
        public DbSet<CV> CVs { get; set; }

        public MvcApplicationForCvDbContext(DbContextOptions<MvcApplicationForCvDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Other options configuration...

            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
