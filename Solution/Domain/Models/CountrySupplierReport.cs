namespace Domain.Models
{
    public class CountrySupplierReport
    {
        public required String Country { get; set; }

        public required Int32 SupplierCount { get; set; }
    }
}