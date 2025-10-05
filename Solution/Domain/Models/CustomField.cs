namespace Domain.Models
{
    public class CustomField
    {
        public int Id { get; set; }

        public int SupplierId { get; set; }

        public required string Name { get; set; }

        public required string Value { get; set; }
    }
}