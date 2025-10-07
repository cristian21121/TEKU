using Domain.Models;

namespace Application.Interfaces
{
    public interface ICountrySupplierReportService
    {
        public List<CountrySupplierReport> Get();
    }
}