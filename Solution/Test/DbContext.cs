using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DbContext : AppDbContext
    {
        public DbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Supplier> SUPPLIER { get; set; }

        public DbSet<Service> SERVICE { get; set; }

        public DbSet<CustomField> CUSTOM_FIELD { get; set; }

        public DbSet<Country> COUNTRY { get; set; }
    }
}