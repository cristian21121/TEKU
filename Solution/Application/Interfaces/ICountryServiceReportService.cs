using Domain.Models;

namespace Application.Interfaces
{
    public interface ICountryServiceReportService
    {
        public List<CountryServiceReport> Get();
    }
}