using Domain.Models;

namespace Domain.Interfaces
{
    public interface ISupplierRepository
    {
        public Supplier? Get(Int32 id);

        public void Create(Supplier supplier);

        public List<Supplier> GetList();

        public void Update(Supplier supplier);
    }
}