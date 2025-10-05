using Domain.Interfaces;
using Domain.Models;

namespace Infrastructure.Persistence
{
    public class CustomFieldRepository : ICustomFieldRepository
    {
        private readonly AppDbContext dbContext;

        public CustomFieldRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(CustomField customField)
        {
            dbContext.CUSTOM_FIELD.Add(customField);
            dbContext.SaveChanges();
        }

        public void Update(CustomField customField)
        {
            dbContext.CUSTOM_FIELD.Update(customField);
            dbContext.SaveChanges();
        }
    }
}