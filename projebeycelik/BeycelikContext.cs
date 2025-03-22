using Microsoft.EntityFrameworkCore;
using projebeycelik.Models;

namespace projebeycelik.Data
{
    public class BeycelikContext : DbContext
    {
        public BeycelikContext(DbContextOptions<BeycelikContext> options)
            : base(options)
        {
        }

        public DbSet<Depo> Depo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Depo>().HasNoKey()
                .HasKey(d => d.Id);  // Depo modelini PK olmadan yapılandırıyoruz
        }
    }
}
