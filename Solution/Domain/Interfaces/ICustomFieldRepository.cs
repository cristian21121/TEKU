using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICustomFieldRepository
    {
        public void Create(CustomField customField);

        public void Update(CustomField customField);
    }
}