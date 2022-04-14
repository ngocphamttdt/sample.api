using Microsoft.EntityFrameworkCore;
using WTPSample.Database.Entities;
using WTPSample.Database.Mapping;

namespace WTPSample.Database
{
    public class WtpContext : DbContext
    {
        public WtpContext(DbContextOptions<WtpContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMapping());

        }
    }
}
