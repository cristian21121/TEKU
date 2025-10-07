using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services
{
    public class CountrySupplierReportService : ICountrySupplierReportService
    {
        private readonly ISupplierRepository supplierRepository;

        public CountrySupplierReportService(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public List<CountrySupplierReport> Get()
        {
            List<Supplier> suppliers = supplierRepository.GetList();

            List<CountrySupplierReport> countrySupplierReports = suppliers
                .SelectMany(s => s.Services
                    .SelectMany(sv => sv.Countries
                        .Select(c => new { Country = c.Name, SupplierId = s.Id })))
                .GroupBy(x => x.Country)
                .Select(g => new CountrySupplierReport
                {
                    Country = g.Key,
                    SupplierCount = g.Select(x => x.SupplierId).Distinct().Count()
                })
                .ToList();

            return countrySupplierReports;
        }
    }
}