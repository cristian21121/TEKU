using Domain.Models;

namespace Application.Interfaces
{
    public interface ICustomFieldService
    {
        public void Create(CustomField customField);

        public void Update(CustomField customField);
    }
}