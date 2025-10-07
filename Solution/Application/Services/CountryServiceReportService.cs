using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class CountryServiceReportService : ICountryServiceReportService
    {
        private readonly IServiceRepository serviceRepository;

        public CountryServiceReportService(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }

        public List<CountryServiceReport> Get()
        {
            List<Service> services = serviceRepository.GetList();

            List<CountryServiceReport> countryServiceReports = services
                .SelectMany(s => s.Countries)
                .GroupBy(c => c.Name)
                .Select(g => new CountryServiceReport
                {
                    Country = g.Key,
                    ServiceCount = services.Count(s => s.Countries.Any(c => c.Name == g.Key))
                })
                .ToList();

            return countryServiceReports;
        }
    }
}