using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class SupplierRepository : ISupplierRepository
    {
        private AppDbContext dbContext;

        public SupplierRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Supplier supplier)
        {
            dbContext.SUPPLIER.Add(supplier);
            dbContext.SaveChanges();
        }

        public Supplier? Get(int id)
        {
            return dbContext.SUPPLIER.AsNoTracking().FirstOrDefault(s => s.Id == id);
        }

        public List<Supplier> GetList()
        {
            return dbContext.SUPPLIER
                .AsNoTracking()
                .Include(s => s.CustomFields)
                .Include(s => s.Services).ThenInclude(s => s.Countries).ToList();
        }
    }
}