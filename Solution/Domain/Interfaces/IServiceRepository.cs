using Domain.Models;

namespace Domain.Interfaces
{
    public interface IServiceRepository
    {
        public void Update(Service service);

        public void Create(Service service);

        public List<Service> GetList();
    }
}