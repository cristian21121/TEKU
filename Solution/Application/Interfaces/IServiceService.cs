using Domain.Models;

namespace Application.Interfaces
{
    public interface IServiceService
    {
        public void Update(Service service);

        public void Create(Service service);
    }
}