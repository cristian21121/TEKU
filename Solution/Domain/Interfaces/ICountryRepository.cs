using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICountryRepository
    {
        public List<Country> GetCreatedList();

        public List<Country> GetList();
        
        public Country GetByCode(String code);

        public List<Country> CreateList(List<Country> countries);
    }
}