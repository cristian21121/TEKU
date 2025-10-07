using Domain.Models;

namespace Domain.Models
{
    public class ServiceCountry
    {
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;

        public int CountryId { get; set; }
        public Country Country { get; set; } = null!;
    }
}