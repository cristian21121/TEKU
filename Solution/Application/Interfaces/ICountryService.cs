using Domain.Models;

namespace Application.Interfaces
{
    public interface ICountryService
    {
        public List<Country> CreateList(List<Country> countries);
    }
}