using Domain.Models;

namespace Application.Interfaces
{
    public interface ISupplierService
    {
        public void Update(Supplier supplier);
        public void Create(Supplier supplier);
    }
}