using Microsoft.EntityFrameworkCore;

namespace MvcApplicationForCV.Models
{
    public class MvcApplicationForCvDbContext : DbContext
    {
        public DbSet<CV> CVs { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public MvcApplicationForCvDbContext(DbContextOptions<MvcApplicationForCvDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
        .HasKey(a => a.AddressId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
