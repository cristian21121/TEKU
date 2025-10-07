using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Supplier> SUPPLIER { get; set; }

        public DbSet<Service> SERVICE { get; set; }

        public DbSet<CustomField> CUSTOM_FIELD { get; set; }

        public DbSet<Country> COUNTRY { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
                .HasIndex(c => c.Code)
                .IsUnique();

            modelBuilder.Entity<Service>()
            .HasMany(s => s.Countries)
            .WithMany(c => c.Services)
            .UsingEntity<Dictionary<string, object>>(
            "ServiceCountry",
            j => j.HasOne<Country>().WithMany().HasForeignKey("CountryId").OnDelete(DeleteBehavior.Restrict),
            j => j.HasOne<Service>().WithMany().HasForeignKey("ServiceId").OnDelete(DeleteBehavior.Restrict),
            j =>
            {
                j.HasKey("ServiceId", "CountryId");
                j.ToTable("ServiceCountries");
            });
        }
    }
}