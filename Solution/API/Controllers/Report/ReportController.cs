using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Report
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ICountrySupplierReportService countrySupplierReportService;
        private readonly ICountryServiceReportService countryServiceReportService;

        public ReportController(
            ICountrySupplierReportService countrySupplierReportService, 
            ICountryServiceReportService countryServiceReportService)
        {
            this.countrySupplierReportService = countrySupplierReportService;
            this.countryServiceReportService = countryServiceReportService;
        }

        [HttpGet("CountrySupplierReport")]
        public IActionResult GetCountrySupplierReport()
        {
            List<CountrySupplierReport> countrySupplierReports = countrySupplierReportService.Get();
            return Ok(countrySupplierReports);
        }

        [HttpGet("CountryServiceReport")]
        public IActionResult GetCountryServiceReport()
        {
            List<CountryServiceReport> countrySupplierReports = countryServiceReportService.Get();
            return Ok(countrySupplierReports);
        }
    }
}