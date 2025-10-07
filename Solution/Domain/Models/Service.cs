namespace Domain.Models
{
    public class Service
    {
        public Int32 Id { get; set; }

        public Int32 SupplierId { get; set; }

        public required String Name { get; set; }

        public Decimal HourValue { get; set; }

        public List<Country> Countries { get; set; } = new();
    }
}