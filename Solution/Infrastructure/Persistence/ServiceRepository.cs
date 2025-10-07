using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext dbContext;

        public ServiceRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Service service)
        {
            dbContext.SERVICE.Add(service);
            dbContext.SaveChanges();
        }

        public List<Service> GetList()
        {
            return dbContext.SERVICE.Include(s => s.Countries).AsNoTracking().ToList();
        }

        public void Update(Service service)
        {
            dbContext.SERVICE.Update(service);
            dbContext.SaveChanges();
        }
    }
}
