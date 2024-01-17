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
    }
}

